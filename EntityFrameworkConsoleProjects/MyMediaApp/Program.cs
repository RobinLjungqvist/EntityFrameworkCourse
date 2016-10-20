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
            //book.BookName = "Pippi Långstrump";
            //Helper.Insert(book);
            var result = Helper.GetAll(book);
            result.ForEach(x => Console.WriteLine(x.BookID + " " + x.BookName));
            Console.WriteLine("Enter Book ID: ");
            var input = Console.ReadLine();
            Console.WriteLine("Enter new book name");
            var newName = Console.ReadLine();
            var bookToUpdate = new Book();
            bookToUpdate.BookID = Convert.ToInt32(input);
            bookToUpdate.BookName = newName;

            Helper.UpdateEntity(bookToUpdate);

            var newBooks = Helper.GetAll(book);

            newBooks.ForEach(x => Console.WriteLine(x.BookID + " : " + x.BookName));

            var movie = new Movie();
            movie.MovieName = "Dallas";
            //Helper.Insert(movie);

            var movieResult = Helper.GetAll(movie);

            movieResult.ForEach(x => Console.WriteLine(x.MovieName));


            Console.ReadKey();

        }
    }
}
