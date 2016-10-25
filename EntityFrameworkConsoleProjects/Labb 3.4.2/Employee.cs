using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3._4._2
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public string Department { get; set; }
        public DateTime Age { get; set; }

            public Employee() { }
        public Employee(int id, string firstname, string lastname, DateTime hiredate, string department, DateTime age)
        {
            ID = id;
            FirstName = firstname;
            LastName = lastname;
            HireDate = hiredate;
            Department = department;
            Age = age;
        }

        public override string ToString()
        {
            return $@"{FirstName} + {LastName}, {DateTime.Now.Year - Age.Year}
Hire Date: {HireDate} 
Department: {Department}
----------------------------------------";
        }

    }
}
