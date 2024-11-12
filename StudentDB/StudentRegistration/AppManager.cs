using Microsoft.EntityFrameworkCore;
using StudentDB.Enum;
using StudentDB.Helpers;
using StudentDB.LogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB.StudentRegistration
{
    internal class AppManager
    {
        private StudentHandler studentHandler;
        private SystemUser currentUser;
        private MenyOption menuOption = new MenyOption();
        public AppManager(StudentHandler handler, SystemUser systemUser)
        {
            studentHandler = handler;
            currentUser = systemUser;
        }

        public void Run()
        {
            bool run = true;

            while (run)
            {
                Printer.PrintMenu();

                switch (Helper.GetIntInput())
                {
                    case 1:
                        menuOption = MenyOption.RegisterNew;
                        bool authorized = CheckIfAuthorized(menuOption, currentUser);
                        if (!authorized)
                        {
                            Printer.PrintAuthorizeMessage();
                            break;
                        }
                        RegisterNew();
                        break;

                    case 2:
                        menuOption = MenyOption.ChangeExisting;
                        authorized = CheckIfAuthorized(menuOption, currentUser);
                        if (!authorized)
                        {
                            Printer.PrintAuthorizeMessage();
                            break;
                        }
                        ChangeExisting();
                        break;

                    case 3:
                        menuOption = MenyOption.DeleteExisting;
                        authorized = CheckIfAuthorized(menuOption, currentUser);
                        if (!authorized)
                        {
                            Printer.PrintAuthorizeMessage();
                            break;
                        }
                        DeleteExisting();
                        break;

                    case 4:
                        ListAll();
                        break;

                    case 5:
                        currentUser = null;
                        run = false;
                        break;

                    default:
                        Printer.PrintDefaultMessage();
                        break;

                }
            }
        }

        private bool CheckIfAuthorized(MenyOption menyOption, SystemUser systemUser)
        {
            if (menuOption == MenyOption.RegisterNew)
            {
                if (currentUser.UserRole.RoleName == "Admin")
                {
                    return true;
                }
            }
            if (menuOption == MenyOption.ChangeExisting)
            {
                if (currentUser.UserRole.RoleName == "Admin" || currentUser.UserRole.RoleName == "Student")
                {
                    return true;
                }
            }
            if (menuOption == MenyOption.DeleteExisting)
            {
                if (currentUser.UserRole.RoleName == "Admin")
                {
                    return true;
                }
            }
            if (menuOption == MenyOption.SetGrade)
            {
                if (currentUser.UserRole.RoleName == "Teacher")
                {
                    return true;
                }
            }
            return false;
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
            Edit(id);
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
                if (students.Any(s => s.StudentId == id) && studentHandler.CheckIfValid(id))
                {
                    return id;
                }
                Printer.PrintError();
                return -1;
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
            int outcome = -1;
            while (true)
            {
                string input = Helper.GetStringInput("Vill du fortsätta med ovanstående post (J/N): ").ToUpper();
                if (input == "J")
                {
                    outcome = students[0].StudentId;
                    break;
                }
                else if (input == "N")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\tOgiltig inmatning! Välj (J/N)");
                }
            }
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
            Delete(id);
        }

        private void Delete(int id)
        {
            bool success = studentHandler.DeleteExisting(id);
            Printer.PrintMessage(success);
        }
    }
}

