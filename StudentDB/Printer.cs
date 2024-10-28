using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
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

        public static void PrintIenumerableList<T>(IEnumerable<T> list)
        {
            foreach (T item in list)
            {
                Console.WriteLine($"\t{item}");
            }
        }
    }
}
