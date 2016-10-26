using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4._3
{
    public static class InputHelper
    {
        public static int GetIntInput(string message)
        {
            int result = -1;
            string input = string.Empty;
            while (!int.TryParse(input, out result))
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
                if (result == -1)
                {
                    Console.WriteLine("Not a valid number");
                }

            }
            return result;
        }
        public static string GetStringInput(string message)
        {
            Console.WriteLine(message);
            var result = Console.ReadLine();

            return result;
        }
    }
}