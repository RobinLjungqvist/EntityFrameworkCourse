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
        #region Book Crud
        public static void Insert<T>(T entity) where T: class
        {
            using(var ctx = new MediaContext())
            {
                ctx.Set<T>().Add(entity);
                ctx.SaveChanges();
            }
        }
        public static List<T> GetAll<T>(T entity) where T : class
        {
            List<T> result = new List<T>();
            using (var ctx = new MediaContext())
            {
                DbSet<T> dbSet = ctx.Set<T>();
                var entities = from x in dbSet select x;
                result.AddRange(entities);

            }
            return result;
        }
        public static Book GetBookByName(string name)
        {
            using (var ctx = new MediaContext())
            {
                var result = from b in ctx.Books
                             where b.BookName == name
                             select b;

                return result.First();
            }
        }
        public static void RemoveEntity<T>(T entity) where T : class
        {
            using (var ctx = new MediaContext())
            {
                DbSet<T> dbSet = ctx.Set<T>();
                dbSet.Remove(entity);
                ctx.SaveChanges();
            }
        }
        public static void DeleteBookByID(int id)
        {
            using (var ctx = new MediaContext())
            {
                var bookToRemove = from x in ctx.Books where x.BookID == id select x;
                ctx.Books.Remove(bookToRemove.FirstOrDefault());
            }
        }

        public static void UpdateEntity<T>(T entity) where T : class
        {
            using (var ctx = new MediaContext())
            {
                ctx.Entry(entity).State = EntityState.Modified;
                ctx.SaveChanges();

            }
        }
        #endregion


    }
}
