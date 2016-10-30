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
                Console.WriteLine("2. Get Author by ID");
                Console.WriteLine("3. Search Author");
                Console.WriteLine("4. Add new Author");
                Console.WriteLine("5. Remove author by ID");
                Console.WriteLine("6. Update Name of Author");
                Console.WriteLine("7. Update Age of Author");
                Console.WriteLine("[Esc] Exit");

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
                            Console.WriteLine( DisplayAuthor(author) );
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
                    case ConsoleKey.D4:
                        string firstName = InputHelper.GetStringInput("Enter the authors Firstname: ");
                        string lastName = InputHelper.GetStringInput("Enter the authors Lastname: ");
                        int age = InputHelper.GetIntInput("Please enter authors age: ");
                        string phoneNumber = InputHelper.GetStringInput("Enter the authors Phone Number: ");
                        PaymentMethods paymentMethod = InputHelper.GetPaymentMethod();
                        var insertResult = dal.InsertAuthor(firstName, lastName, age, phoneNumber, paymentMethod);
                        Console.WriteLine(insertResult);
                        break;
                    case ConsoleKey.D5:
                        var authorIDToRemove = InputHelper.GetIntInput("Enter the ID of the author you want to remove: ");
                        var removalResult = dal.RemoveAuthorByID(authorIDToRemove);
                        Console.WriteLine(removalResult);
                        break;
                    case ConsoleKey.D6:
                        var authorToUpdateID = InputHelper.GetIntInput("Enter the ID of the author you want to update.");
   
                        
                            var authorToUpdate = dal.GetAuthorByID(authorToUpdateID);
                        if (authorToUpdate != null)
                        { 
                            var authorNewFirstName = InputHelper.GetStringInput($"The old first name was {authorToUpdate.FirstName} please update name: ");
                            var authorNewLastName = InputHelper.GetStringInput($"The old first name was {authorToUpdate.LastName} please update name: ");

                            authorToUpdate.FirstName = authorNewFirstName;
                            authorToUpdate.LastName = authorNewLastName;
                            var updateResult = dal.UpdateAuthor(authorToUpdate);
                            Console.WriteLine(updateResult);
                        }
                        else
                        {
                            Console.WriteLine("Couldn't find a user with id {0}", authorToUpdateID );
                        }

                        break;
                    case ConsoleKey.D7:
                        var authorIDAgeUpdate = InputHelper.GetIntInput("Enter the ID of the author you want to update.");
                        var authorToChangeAge = dal.GetAuthorByID(authorIDAgeUpdate);
                        if (authorToChangeAge != null)
                        {
                            var newAge = InputHelper.GetIntInput($"The old age was {authorToChangeAge.Age}. Please Enter new age: ");
                            authorToChangeAge.Age = newAge;
                            var ageUpdateResult = dal.UpdateAuthor(authorToChangeAge);
                            Console.WriteLine(ageUpdateResult); 
                        }
                        else
                        {
                            Console.WriteLine("Could not find a user with ID {0}", authorIDAgeUpdate);
                        }
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        Console.WriteLine("Please choose one of the alternatives using the number keys.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            } while (true);
        }

        public void DisplayAuthors(List<Authors> list)
        {
            list.ForEach(x => Console.WriteLine(DisplayAuthor(x)));

        }
        public string DisplayAuthor(Authors author)
        {
            var authorInfo = $"ID: {author.AuthorID} Name: {author.FirstName} {author.LastName} Age: {author.Age} \ntel: {author.HomeTel} Payment Method: {author.PaymetMethod}\n---------------------------------------";
            return authorInfo;
        }

    }
}
