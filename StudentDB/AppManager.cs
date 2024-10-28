using Microsoft.EntityFrameworkCore;
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
            this.studentHandler = handler;
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
            int searchPost = ChoosePost("söka på");
            string searchInput = Helper.GetStringInput("Skriv in sökord: ");
            List<Student> students = studentHandler.GetMatches(searchPost, searchInput);
            if (students == null)
            {
                PrintError();
                return;
            }
            Printer.PrintIenumerableList(students);
            int id = students[0].StudentId;
            if(students.Count > 1)
            {
                id = ChooseExisting();
                if (!studentHandler.CheckIfValid(id))
                {
                    PrintError();
                    return;
                }
            }
            int editPost = ChoosePost("editera");
            string edit = Helper.GetStringInput("Skriv in ändring: ");
            bool success = studentHandler.ChangeExisting(id, editPost, edit);
            PrintMessage(success);
        }

        private int ChooseExisting()
        {
            Console.Write($"\n\tSkriv in Id på den student du önskar editera: ");
            int id = Helper.GetIntInput();
            return id;
        }

        private int ChoosePost(string option)
        {
            int editPost;
            do
            {
                Console.Write($"\n\tSkriv in nummer på den post du vill {option} " +
                    $"(1. Förnamn, 2. Efternamn, 3. Stad): ");
                editPost = Helper.GetIntInput();

                if (editPost < 1 || editPost > 3)
                {
                    Console.WriteLine("\n\tOgiltig inmatning!");
                }
            } while (editPost < 1 || editPost > 3);
            return editPost;
        }

        private void ListAll()
        {
            Printer.PrintIenumerableList(studentHandler.GetAllStudents());
            Console.ReadLine();
        }

        private void Delete()
        {
            int searchPost = ChoosePost("söka på");
            string searchInput = Helper.GetStringInput("Skriv in sökord: ");
            List<Student> students = studentHandler.GetMatches(searchPost, searchInput);
            if (students == null)
            {
                PrintError();
                return;
            }
            Printer.PrintIenumerableList(students);
            int id = students[0].StudentId;
            if (students.Count > 1)
            {
                id = ChooseExisting();
                if (!studentHandler.CheckIfValid(id))
                {
                    PrintError();
                    return;
                }
            }
            bool success = studentHandler.DeleteExisting(id);
            PrintMessage(success);
        }
    }
}

