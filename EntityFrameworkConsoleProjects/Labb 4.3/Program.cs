using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4._3
{
    class Program
    {
        static void Main(string[] args)
        {
            var DB = new BookDBHelper();

            var authors = DB.GetAuthorThatStartsWith("as");

            authors.ForEach(x => Console.WriteLine(x.FirstName));
            Console.ReadKey();
        }
    }
}
