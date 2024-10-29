using Microsoft.EntityFrameworkCore;
using StudentDB.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    internal class AppManager
    {
        private StudentHandler studentHandler;

        public AppManager(StudentHandler handler)
        {
            studentHandler = handler;
        }

        public void Run()
        {
            bool run = true;

            while (run)
            {
                //studentHandler.CreateAStudent();
                Printer.PrintMenu();

                switch (Helper.GetIntInput())
                {
                    case 1:
                        RegisterNew();
                        break;

                    case 2:
                        ChangeExisting();
                        break;

                    case 3:
                        DeleteExisting();
                        break;

                    case 4:
                        ListAll();
                        break;

                    case 5:
                        run = false;
                        break;

                    default:
                        Printer.PrintDefaultMessage();
                        break;

                }
            }
        }

        //private void PrintMessage(bool success)
        //{
        //    if (success)
        //    {
        //        Console.WriteLine($"\n\tÄndringen är nu genomförd.");
        //        Console.ReadLine();
        //    }
        //    else
        //    {
        //        Printer.PrintError();
        //    }
        //}

        private void RegisterNew()
        {
            string firstName = Helper.GetStringInput("Skriv in förnamn: ");
            string lastName = Helper.GetStringInput("Skriv in efternamn: ");
            string city = Helper.GetStringInput("Skriv in stad: ");
            studentHandler.RegisterNew(firstName, lastName, city);
        }

        private void ChangeExisting()
        {
            List<Student> students = Search();
            if (students.Count == 0)
            {
                Printer.PrintError();
                return;
            }
            Printer.PrintList(students);
            int id = Choose(students);
            if(id == -1)
            {
                return;
            }
            //if (students.Count > 1)
            //{
            //    Printer.PrintIenumerableList(students);
            //    id = ChooseExisting();
            //    if (!studentHandler.CheckIfValid(id))
            //    {
            //        PrintError();
            //        return;
            //    }
            //}
            //else
            //{
            //    id = students[0].StudentId;
            //}
            Edit(id);
            //ModifyField field = ChooseField("editera");
            //string edit = Helper.GetStringInput("Skriv in ändring: ");
            //bool success = studentHandler.ChangeExisting(id, field, edit);
            //PrintMessage(success);
        }

        private List<Student> Search()
        {
            ModifyField field = ChooseField("söka på");
            string searchInput = Helper.GetStringInput("Skriv in sökord: ");
            return studentHandler.GetMatches(field, searchInput);
        }

        private int Choose(List<Student> students)
        {
            if (students.Count > 1)
            {
                int id = ChooseExisting();
                if (!studentHandler.CheckIfValid(id))
                {
                    Printer.PrintError();
                    return -1;
                }
                return id;
            }
            else
            {
                return CheckIfProceed(students);
            }
        }

        private void Edit(int id)
        {
            ModifyField field = ChooseField("editera");
            string edit = Helper.GetStringInput("Skriv in ändring: ");
            bool success = studentHandler.ChangeExisting(id, field, edit);
            Printer.PrintMessage(success);
        }

        private int ChooseExisting()
        {
            Console.Write($"\n\tSkriv in Id på den student du önskar välja: ");
            int id = Helper.GetIntInput();
            return id;
        }

        private int CheckIfProceed(List<Student> students)
        {
            int outcome = 0;
            string input;
            do
            {
                Console.Write("\n\tVill du fortsätta med ovanstående post (J/N): ");
                input = Console.ReadLine().ToUpper();
                if (input == "J")
                {
                    outcome = students[0].StudentId;
                }
                else if (input == "N")
                {
                    outcome = -1;
                }
                else
                {
                    Console.WriteLine("\n\tOgiltig inmatning! Välj (J/N)");
                }
            } while (input != "J" && input != "N");
            return outcome;

        }

        private ModifyField ChooseField(string option)
        {
            int editPost;
            do
            {
                Console.Write($"\n\tSkriv in nummer på det fält du vill {option} " +
                    $"(1. {FieldDescriptions.GetDescription(ModifyField.FirstName)}, " +
                    $"2. {FieldDescriptions.GetDescription(ModifyField.LastName)}, " +
                    $"3. {FieldDescriptions.GetDescription(ModifyField.City)}): ");
                editPost = Helper.GetIntInput();

                if (editPost < 1 || editPost > 3)
                {
                    Console.WriteLine("\n\tOgiltig inmatning!");
                }
            } while (editPost < 1 || editPost > 3);
            return (ModifyField)editPost;
        }

        private void ListAll()
        {
            Printer.PrintList(studentHandler.GetAllStudents());
            Console.ReadLine();
        }

        private void DeleteExisting()
        {
            List<Student> students = Search();
            if (students.Count == 0)
            {
                Printer.PrintError();
                return;
            }
            Printer.PrintList(students);
            int id = Choose(students);
            if (id == -1)
            {
                return;
            }
            //int id;
            //if (students.Count > 1)
            //{
            //    Printer.PrintIenumerableList(students);
            //    id = ChooseExisting();
            //    if (!studentHandler.CheckIfValid(id))
            //    {
            //        PrintError();
            //        return;
            //    }
            //}
            //else
            //{
            //    id = students[0].StudentId;
            //}
            Delete(id);
        }

        private void Delete(int id)
        {
            bool success = studentHandler.DeleteExisting(id);
            Printer.PrintMessage(success);
        }
    }
}

