using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper
{
    public static class BookModel
    {
        public static Entities ctx = new Entities();
        public static IEnumerable<Book> GetAllBooks()
        {

                var books = ctx.Books.Select(x => x);
                return books;

        }
        public static void UpdateBook(Book book)
        {

            var result = ctx.Books.Where(x => x.BookID == book.BookID);

            result.FirstOrDefault().BookName = book.BookName;

                ctx.SaveChanges();

        }

        public static void BookDelete(Book book)
        {
            var result = from x in ctx.Books where x.BookID == book.BookID select x;

            ctx.Books.Remove(result.FirstOrDefault());
            ctx.SaveChanges();

        }
        public static void InsertBook(Book book)
        {

                ctx.Books.Add(book);
                ctx.SaveChanges();
            
        }
        

        public static string GetConnection()
        {
            string connectionString = string.Empty;
           using(var ctx = new Entities())
            {
                connectionString = ctx.Database.Connection.ConnectionString;
            }
            return connectionString;
        }


    }
}
