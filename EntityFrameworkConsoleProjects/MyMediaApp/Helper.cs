using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMediaApp
{
    public static class Helper
    {
        public static MediaContext ctx = new MediaContext();
        #region Book Crud
        public static void Insert(this Book book)
        {
            using(ctx)
            {
                ctx.Books.Add(book);
                ctx.SaveChanges();
            }
        }
        public static List<string> GetAllBooks()
        {
            List<string> books = new List<string>();
            using (ctx)
            {
                var dbBooks = from x in ctx.Books select x;
                dbBooks.ForEachAsync(x => books.Add(x.BookID + " : " + x.BookName));
            }
            return books;
        }
        public static Book GetBookByName(string name)
        {
            using (ctx)
            {
                var result = from b in ctx.Books
                             where b.BookName == name
                             select b;

                return result.First();
            }
        }
        public static void RemoveBook(Book book)
        {
            using (ctx)
            {
                ctx.Books.Remove(book);
                ctx.SaveChanges();
            }
        }
        public static void DeleteBookByID(int id)
        {
            using (ctx)
            {
                var bookToRemove = from x in ctx.Books where x.BookID == id select x;
                ctx.Books.Remove(bookToRemove.FirstOrDefault());
            }
        }

        public static void UpdateBookByID(Book book)
        {
            using (ctx)
            {
                var bookToUpdate = ctx.Books.First(x => x.BookID == book.BookID);

                bookToUpdate.BookName = book.BookName;
                ctx.SaveChanges();

            }
        }
        #endregion


    }
}
