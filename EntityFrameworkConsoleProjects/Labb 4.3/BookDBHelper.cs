using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4._3
{
    public class BookDBHelper
    {
        public List<Authors> GetAllAuthors()
        {
            List<Authors> authors;
            using(var ctx = new BooksContext())
            {
                authors = ctx.Authors.ToList();

            }
            return authors;
        }

        public List<Authors> GetAuthorThatStartsWith(string searchTerm)
        {

            List<Authors> authors;
            var search = searchTerm;
            using (var ctx = new BooksContext())
            {
                authors = ctx.Authors.Where(x => x.FirstName.StartsWith(search) || x.LastName.StartsWith(search)).ToList();

            }
            return authors;

        }

        public string InsertAuthor(string name, string lastName, int age, string telNr, PaymentMethods paymentMethod)
        {
            var author = new Authors() { FirstName = name, LastName = lastName, Age = age, HomeTel = telNr, PaymetMethod = paymentMethod };
            string message = string.Empty;
            try
            {
                using (var ctx = new BooksContext())
                {
                    ctx.Authors.Add(author);
                    ctx.SaveChanges();
                    message = "Author was added";
                }
            }
            catch (Exception e)
            {
                message = "Couldn't add author";
                throw e;

                
            }
                return message;
        }

        public Authors GetAuthorByID(int id)
        {
            Authors author;
            using (var ctx = new BooksContext())
            {
                author = ctx.Authors.Where(x => x.AuthorID == id).FirstOrDefault();

            }
            return author;
        }

        public string RemoveAuthorByID(int id)
        {
            using (var ctx = new BooksContext())
            {
                var author = ctx.Authors.Where(x => x.AuthorID == id).FirstOrDefault();
                if(author != null)
                {
                    ctx.Authors.Remove(author);
                    ctx.SaveChanges();
                    return $"The author with id {id} was deleted";
                }
                else
                {
                    return $"No author was found with id: {id}";
                }
            }

        }

        public string UpdateAuthor(Authors author)
        {
            string message = string.Empty;

            try
            {
                using (var ctx = new BooksContext())
                {
                    ctx.Entry(author).State = EntityState.Modified;
                    ctx.SaveChanges();
                    message = "Author was updated.";
                }
            }
            catch (Exception ex)
            {
                message = "Couldn't update author";
                throw ex;
            }

            return message;
            
        }

        public List<Authors> SearchAuthor(string search)
        {
            using(var ctx = new BooksContext())
            {
                var authors = ctx.Authors.Where(x => x.FirstName.StartsWith(search) || x.LastName.StartsWith(search)).ToList();
                return authors;
            }
        }



    }
}
