using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Labb5
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = CreateEmployees();

            //Uppgift 1
            //IEnumerable<Employee> query = from e in employees
            //                              where e.HiredDate.CompareTo(DateTime.Now.AddYears(-25)) < 0
            //                              orderby e.Name
            //                              select e;
            //query.ToList().ForEach(x => Console.WriteLine(x.Name));

            //Uppgift 2

            //employees.ForEach(x => Console.Write(x.Name + " "));

            //IEnumerable<Employee> query = from x in employees
            //                              where x.ID > 4
            //                              select x;

            //employees.Add(new Employee("Allan", DateTime.Now, 11));

            //Console.WriteLine("\n------------------------------------------------------------");

            //foreach (var emp in query)
            //{
            //    Console.Write(emp.Name + " ");
            //}

            //Uppgift 3
            //var currentTypes = GetCurrentTypes();

            //currentTypes.ToList().ForEach(x => Console.WriteLine(x));

            //Uppgift 4 och 5

            //GetCurrentProcesses();

            //Uppgift 6

            Employee[] employeeArray = new Employee[4];

            employeeArray[0] = new Employee("Kalle", DateTime.Now, 1);
            employeeArray[1] = new Employee("Lisa", DateTime.Now, 2);
            employeeArray[2] = new Employee("Algot", DateTime.Now, 3);
            employeeArray[3] = new Employee("Anna", DateTime.Now, 4);



            var employee = Array.Find(employeeArray, FindNameLisa);


            Console.WriteLine(employee.Name);

            Console.ReadKey();
        }

        public static List<Employee> CreateEmployees()
        {
            var rnd = new Random();

            var employees = new List<Employee>() {
            new Employee("Kalle", DateTime.Now.AddYears(-rnd.Next(1,50)), 1),
            new Employee("Lisa", DateTime.Now.AddYears(-rnd.Next(1,50)), 2),
            new Employee("Frans", DateTime.Now.AddYears(-rnd.Next(1,50)), 3),
            new Employee("Nisse", DateTime.Now.AddYears(-rnd.Next(1,50)), 4),
            new Employee("Alfred", DateTime.Now.AddYears(-rnd.Next(1,50)), 5),
            new Employee("Mahmoud", DateTime.Now.AddYears(-rnd.Next(1,50)), 6),
            new Employee("Indira", DateTime.Now.AddYears(-rnd.Next(1,50)), 7),
            new Employee("Admir", DateTime.Now.AddYears(-rnd.Next(1,50)), 8),
            new Employee("Elmin", DateTime.Now.AddYears(-rnd.Next(1,50)), 9)

        };

            return employees;
        }

        public static void GetCurrentProcesses()
        {

            //Uppgift 4
            var query = from p in Process.GetProcesses()
                        orderby p.ProcessName ascending
                        select new XElement("Process", new XAttribute("Name", p.ProcessName), new XAttribute("PID", p.Id));

            var xml = new XElement("Processes", query);
            //Console.WriteLine(xml);

            IEnumerable<int> pids = from e in xml.Descendants()
                                    where e.Attribute("Name").Value == "devenv"
                                    orderby (int)e.Attribute("PID") ascending
                                    select (int)e.Attribute("PID");

            foreach (var pid in pids)
            {
                Console.WriteLine(pid);
            }



        }

        public static bool FindNameLisa(Employee e)
        {
            return e.Name == "Lisa";
        }


    }

    
}
