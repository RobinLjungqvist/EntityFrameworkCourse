using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMediaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book();
            book.BookName = "Nalle Puh";
            Helper.Insert(book);
            var books = Helper.GetAllBooks();
            books.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("Enter Book ID: ");
            var input = Console.ReadLine();
            Console.WriteLine("Enter new book name");
            var newName = Console.ReadLine();
            var bookToUpdate = new Book();
            bookToUpdate.BookID = Convert.ToInt32(input);
            bookToUpdate.BookName = newName;

            Helper.UpdateBookByID(bookToUpdate);

            var newBooks = Helper.GetAllBooks();

            Console.ReadKey();

        }
    }
}
