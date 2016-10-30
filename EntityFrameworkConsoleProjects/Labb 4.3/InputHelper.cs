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

        public static PaymentMethods GetPaymentMethod()
        {
            do
            {
                Console.WriteLine("Please choose a payment method for the author");
                Console.WriteLine($"1. {PaymentMethods.Bank}");
                Console.WriteLine($"2. {PaymentMethods.Cash}");
                Console.WriteLine($"3. {PaymentMethods.Card}");

                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        return PaymentMethods.Bank;
                    case ConsoleKey.D2:
                        return PaymentMethods.Cash;
                    case ConsoleKey.D3:
                        return PaymentMethods.Card;
                    default:
                        Console.Clear();
                        Console.WriteLine("You must choose a valid payment method.");
                        break;
                }
            } while (true);

            


        }


    }
}