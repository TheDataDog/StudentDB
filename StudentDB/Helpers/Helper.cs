using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB.Helpers
{
    internal class Helper
    {
        public static string GetStringInput(string instruction)
        {
            string input;
            do
            {
                Console.Write($"\n\t{instruction}");
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("\n\tOgiltig inmatning!");
                }

            } while (string.IsNullOrEmpty(input));

            return input;
        }

        public static int GetIntInput()
        {
            int input;
            bool success;
            do
            {
                success = int.TryParse(Console.ReadLine(), out input);
                if (!success)
                {
                    Console.Write("\n\tEndast siffror, försök igen: ");
                }
            } while (!success);
            return input;
        }
    }
}
