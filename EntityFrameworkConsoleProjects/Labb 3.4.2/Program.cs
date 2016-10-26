using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3._4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = CreateEmployees();

            do
            {
                Console.WriteLine(
    @"What do you want to do?
1. ShowAllEmployees
2. ShowAllEmplyees sorted by FirstName
3. ShowAllEmploytees sorted by LastName
4. ShowAllEmployees from certain department
5. ShowAllEmployees hired this year
6. Show first Employee from certain department
7. Show Employees over a Certain Age
8. Show Employees under a Certain Age
9. Search
");

                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        employees.Display();
                        break;
                    case ConsoleKey.D2:
                        var employteesSortedByFirstName = employees.SortByFirstName();
                        employteesSortedByFirstName.Display();
                        break;
                    case ConsoleKey.D3:
                        var employeesSortedByLastname = employees.SortByLastName();
                        employeesSortedByLastname.Display();
                        break;
                    case ConsoleKey.D4:
                        string department = GetUserInput("Please enter departement: ");
                        var employeesSortedByDepartment = employees.GetAllFromDepartment(department);
                        employeesSortedByDepartment.Display();
                        break;
                    case ConsoleKey.D5:
                        var employeesHiredThisYear = employees.HiredThisYear();
                        employeesHiredThisYear.Display();
                        break;
                    case ConsoleKey.D6:
                        string dpt = GetUserInput("Please enter department: ");
                        var employee = employees.GetFirstFromDepartment(dpt);
                        if(employee != null)
                        {
                            Console.WriteLine(employee.ToString());
                        }
                        break;
                    case ConsoleKey.D7:
                        int ageOver;
                        var inputOver = GetUserInput("Enter an age to search for users over that age: ");
                        if(int.TryParse(inputOver, out ageOver))
                        {
                           
                            var employeesOverCertainAge = employees.GetAllOverTheAgeOf(ageOver);
                            employeesOverCertainAge.Display();

                        }
                        else
                        {
                            Console.WriteLine("You didn't enter a valid number.");
                        }
                        break;
                    case ConsoleKey.D8:
                        int ageUnder;
                        var inputUnder = GetUserInput("Enter an age to search for users under that age: ");
                        if (int.TryParse(inputUnder, out ageUnder))
                        {

                            var employeesOverCertainAge = employees.GetAllUnderTheAgeOf(ageUnder);
                            employeesOverCertainAge.Display();

                        }
                        else
                        {
                            Console.WriteLine("You didn't enter a valid number.");
                        }
                        break;
                    case ConsoleKey.D9:
                        var userInput = GetUserInput("Please enter a searchterm: ");
                        var searchResult = employees.SearchEmployee(userInput);
                        searchResult.Display();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Press Any Key to Continue...");
                Console.ReadKey(true);
                Console.Clear();

            } while (true);

        }

        private static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            var department = Console.ReadLine();
            return department;
        }

        private static List<Employee> CreateEmployees()
        {
            var employees = new List<Employee>();

            employees.Add(new Employee(1, "Nisse", "Holgersson", DateTime.Now, "Warehouse", DateTime.Now.AddYears(-24)));
            employees.Add(new Employee(2, "Adam", "Svensson", DateTime.Now.AddDays(-72), "Warehouse", DateTime.Now.AddYears(-32)));
            employees.Add(new Employee(3, "Anders", "Illomeri", DateTime.Now.AddYears(-32), "Warehouse", DateTime.Now.AddYears(-52)));
            employees.Add(new Employee(4, "Lina", "Johansson", DateTime.Now.AddYears(-2), "Production", DateTime.Now.AddYears(-22)));
            employees.Add(new Employee(5, "Emma", "Johansson", DateTime.Now.AddYears(-2), "Production", DateTime.Now.AddYears(-25).AddDays(7)));
            employees.Add(new Employee(6, "Björn", "Lundberg", DateTime.Now.AddYears(-10), "Management", DateTime.Now.AddYears(-46)));
            employees.Add(new Employee(7, "Lennart", "Andersson", DateTime.Now.AddYears(-35), "Management", DateTime.Now.AddYears(-62)));
            employees.Add(new Employee(8, "Lena", "Nilsson", DateTime.Now.AddYears(-10), "WareHouse", DateTime.Now.AddYears(-50)));



            return employees;
            
        }
    }
}
