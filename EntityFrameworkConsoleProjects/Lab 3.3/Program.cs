using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameList = new List<string> {
                "Nisse",
                "Anna",
                "Alfons",
                "Danno",
                "Pernilla",
                "Lisa",
                "Olle",
                "Algot" };

            while (true)
            {
                Console.WriteLine(
                    @"What do you want to do?
1. Show All Names
2. Show All Names that Starts with A
3. Show All Names that Contains A
4. Show All Names that Contains A but no S
[Q]uit");
            
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D2:
                        DisplayList(NamesStartWithA(nameList));
                        Console.ReadKey(true);
                        Console.Clear();

                        break;
                    case ConsoleKey.D3:
                        DisplayList(AllNamesWith(nameList, "A"));
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    case ConsoleKey.D1:
                        DisplayList(nameList);
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    case ConsoleKey.D4:
                        DisplayList(StartwithContainsNo(nameList, "A", "S"));
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    case ConsoleKey.Q:
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("Not a valid choice.");
                        break;
                }
            }



        }

        private static List<string> StartwithContainsNo(List<string> nameList, string start, string exclude)
        {
            var searchResult = NamesStartWithA(nameList);
            var resultExcludeS = searchResult.Where(x => !(x.Contains(exclude.ToUpper())) && !(x.Contains(exclude.ToLower()))).ToList();
            return resultExcludeS;
        }

        public static List<string> NamesStartWithA(List<string> list)
        {
            //var searchResult = from x in list
            //            where (x[0] == 'A' || x[0] == 'a')
            //            select x;
            var searchResult = list.Where(x => x.StartsWith("A") || x.StartsWith("a"));
            var names = searchResult.ToList();
            return names;
        }
        public static List<string> AllNamesWith(List<string> list, string contain)
        {
            var names = list.Where(x => x.Contains(contain.ToUpper()) || x.Contains(contain.ToLower())).ToList();
            return names;
        }

        public static void DisplayList(List<string> list)
        {
            list.ForEach(x => Console.WriteLine(x));
        }
    }
}
