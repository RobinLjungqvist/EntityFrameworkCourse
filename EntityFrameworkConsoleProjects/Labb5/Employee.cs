using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb5
{
    class Employee
    {
        public string Name { get; set; }
        public DateTime HiredDate { get; set; }
        public int ID { get; set; }

        public Employee(string name, DateTime date, int id)
        {
            this.Name = name;
            this.HiredDate = date;
            this.ID = id;
        }
    }
}
