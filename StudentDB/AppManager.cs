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
                        Delete();
                        break;

                    case 4:
                        ListAll();
                        break;

                    case 5:
                        run = false;
                        break;

                    default:
                        PrintDefaultMessage();
                        break;

                }
            }
        }

        private void PrintDefaultMessage()
        {
            Console.WriteLine("\n\tOgiltigt val! Välj 1-5!");
            Console.ReadLine();
        }

        private void PrintError()
        {
            Console.WriteLine($"\n\tVi hittade ingen matchande student.");
            Console.ReadLine();
        }

        private void PrintMessage(bool success)
        {
            if (success)
            {
                Console.WriteLine($"\n\tÄndringen är nu genomförd.");
                Console.ReadLine();
            }
            else
            {
                PrintError();
            }
        }

        private void RegisterNew()
        {
            string firstName = Helper.GetStringInput("Skriv in förnamn: ");
            string lastName = Helper.GetStringInput("Skriv in efternamn: ");
            string city = Helper.GetStringInput("Skriv in stad: ");
            studentHandler.RegisterNew(firstName, lastName, city);
        }

        private void ChangeExisting()
        {
            List<Student> students = SearchStudents();
            if (students.Count == 0)
            {
                PrintError();
                return;
            }
            int id;
            if (students.Count > 1)
            {
                Printer.PrintIenumerableList(students);
                id = ChooseExisting();
                if (!studentHandler.CheckIfValid(id))
                {
                    PrintError();
                    return;
                }
            }
            else
            {
                id = students[0].StudentId;
            }
            ModifyField field = ChooseField("editera");
            string edit = Helper.GetStringInput("Skriv in ändring: ");
            bool success = studentHandler.ChangeExisting(id, field, edit);
            PrintMessage(success);
        }

        private List<Student> SearchStudents()
        {
            ModifyField field = ChooseField("söka på");
            string searchInput = Helper.GetStringInput("Skriv in sökord: ");
            return studentHandler.GetMatches(field, searchInput);
        }

        private int ChooseExisting()
        {
            Console.Write($"\n\tSkriv in Id på den student du önskar välja: ");
            int id = Helper.GetIntInput();
            return id;
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
            Printer.PrintIenumerableList(studentHandler.GetAllStudents());
            Console.ReadLine();
        }

        private void Delete()
        {
            List<Student> students = SearchStudents();
            if (students.Count == 0)
            {
                PrintError();
                return;
            }
            int id;
            if (students.Count > 1)
            {
                Printer.PrintIenumerableList(students);
                id = ChooseExisting();
                if (!studentHandler.CheckIfValid(id))
                {
                    PrintError();
                    return;
                }
            }
            else
            {
                id = students[0].StudentId;
            }
            bool success = studentHandler.DeleteExisting(id);
            PrintMessage(success);
        }
    }
}

