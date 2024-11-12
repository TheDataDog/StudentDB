using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB.Helpers
{
    internal class Printer
    {
        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine($"\n\tHANTERA STUDENTER\n" +
                            $"\t[1] - Registrera ny\n" +
                            $"\t[2] - Ändra befintlig\n" +
                            $"\t[3] - Radera\n" +
                            $"\t[4] - Lista samtliga\n" +
                            $"\t[5] - Avsluta");
            Console.Write("\n\tVälj: ");
        }

        public static void PrintDefaultMessage()
        {
            Console.WriteLine("\n\tOgiltigt val! Välj 1-5!");
            Console.ReadLine();
        }
        public static void PrintError()
        {
            Console.WriteLine($"\n\tVi hittade ingen matchande student.");
            Console.ReadLine();
        }
        public static void PrintAuthorizeMessage()
        {
            Console.WriteLine("\n\tDu har inte behörighet!");
            Console.ReadLine();
        }

        public static void PrintMessage(bool success)
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

        public static void PrintList<T>(List<T> list)
        {
            Console.WriteLine();
            foreach (T item in list)
            {
                Console.WriteLine($"\t{item}");
            }
        }
    }
}
