using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a number: ");
                var input = Console.ReadLine();
                try
                {
                    //var inputNumber = Helper.StringToDouble(input);
                    var inputNumber = input.ToFloat();
                    Console.WriteLine(inputNumber * 12);
                    Console.ReadKey();
                    return;
                }
                catch
                {
                    Console.WriteLine("You didn't enter a valid number please try again");
                    Console.ReadKey();
                    Console.Clear();
                } 
            }
        }
    }
}
