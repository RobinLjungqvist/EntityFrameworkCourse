using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var author = new Authors();

            author.FirstName = "Tom";
            author.LastName = "Clancy";
            author.PaymetMethod = PaymentMethods.Bank;
            author.HomeTel = "037112345";

            var title = new Titles();

            title.Title = "Splinter Cell";
            title.Copyright = "Bonnier";
            title.EditionNumber = 154;
            title.ISBN = "123145747742414";

            ////author.Titles.Add(title);



            using (var ctx = new BooksContext())
            {
                ctx.Authors.Add(author);
                ctx.SaveChanges();
            }

            using (var ctx = new BooksContext())
            {
                var authorToDisplay = ctx.Authors.Where(x => x.FirstName == "Tom").FirstOrDefault();

                Console.WriteLine(authorToDisplay.FirstName + " " + authorToDisplay.LastName +
                    ". Payment method: " + authorToDisplay.PaymetMethod);

            }

            Console.ReadKey();
        }
    }
}
