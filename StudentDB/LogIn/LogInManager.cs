using Microsoft.Identity.Client;
using StudentDB.Helpers;
using StudentDB.StudentRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB.LogIn
{
    internal class LogInManager
    {
        private LogInHandler logInHandler;

        public LogInManager(LogInHandler logInHandler)
        {
            this.logInHandler = logInHandler;
        }
        public SystemUser LogIn()
        {
            SystemUser systemUser;
            while (true)
            {
                Console.WriteLine("\n\tINLOGGNING");
                string userName = GetUserName();
                string password = GetPassword();
                systemUser = ValidateUser(userName, password);
                if (systemUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\tFelaktigt Användarnamn!");
                    bool proceed = CheckIfProceed();
                    if (!proceed)
                    {
                        break;
                    }
                }
            }
            return systemUser;
        }
        private bool CheckIfProceed()
        {
            bool outcome = false;
            while (true)
            {
                string input = Helper.GetStringInput("Vill du fortsätta försöka igen (J/N): ").ToUpper();
                if (input == "J")
                {
                    outcome = true;
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

        public string GetUserName()
        {
            Console.Write("\n\tAnvändarnamn: ");
            return Console.ReadLine();
        }
        public string GetPassword()
        {
            Console.Write("\tLösenord: ");
            return Console.ReadLine();
        }
        //public bool CheckIfValidUserName(string userName)
        //{
        //    return logInHandler.CheckIfValidUserName(userName);
        //}
        public SystemUser ValidateUser(string userName, string password)
        {
            try
            {
                return logInHandler.ValidateUser(userName, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
}
