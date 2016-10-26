using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4._3
{
    public class Application
    {
        BookDBHelper dal;

        public Application()
        {
            dal = new BookDBHelper();
        }
        public void Run()
        {
            do
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1. Show all Authors");
                Console.WriteLine("2. Get author by ID");
                Console.WriteLine("3. Search author");
                Console.WriteLine("4.");

                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        var allAuthors = dal.GetAllAuthors();
                        DisplayAuthors(allAuthors);
                        break;
                    case ConsoleKey.D2:
                        var authorID = InputHelper.GetIntInput("Please enter author ID: ");
                        var author = dal.GetAuthorByID(authorID);
                        if(author != null)
                        {
                            DisplayAuthor(author);
                        }
                        else
                        {
                            Console.WriteLine("No author with that id was found");
                        }
                        break;
                    case ConsoleKey.D3:
                        var searchTerm = InputHelper.GetStringInput("Enter search term: ");
                        var searchResultAuthors = dal.SearchAuthor(searchTerm );

                        if(searchResultAuthors.Count > 1)
                        {
                            Console.WriteLine("Found more than one author.");
                        }
                        DisplayAuthors(searchResultAuthors);
                        break;

                    default:
                        Console.WriteLine("Please choose one of the alternatives using the number keys.");
                        break;
                }

                Console.ReadKey();
            } while (true);
        }

        public void DisplayAuthors(List<Authors> list)
        {
            list.ForEach(x => Console.WriteLine(DisplayAuthor(x)));

        }
        public string DisplayAuthor(Authors author)
        {
            var authorInfo = $"{author.FirstName} {author.LastName} | tel: {author.HomeTel} | Payment: {author.PaymetMethod}";
            return authorInfo;
        }

    }
}
