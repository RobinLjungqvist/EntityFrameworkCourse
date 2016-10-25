using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3._4._2
{
    public static class EmployeeExtensions
    {
        public static void Display(this List<Employee> list)
        {

            if (list != null)
            {
                list.ForEach(x => Console.WriteLine(x.ToString())); 
            }
        }
        public static List<Employee> SortByFirstName(this List<Employee> list)
        {
            var result = list.OrderBy(x => x.FirstName).ToList();
            return result;
        }
        public static List<Employee> SortByLastName(this List<Employee> list)
        {
            var result = list.OrderBy(x => x.LastName).ToList();
            return result;
        }
        public static List<Employee> GetAllFromDepartment(this List<Employee> list, string Department)
        {
            var result = list.Where(x => x.Department.ToLower() == Department.ToLower()).ToList();
            return result;
        }
        public static List<Employee> SearchEmployee(this List<Employee> list, string search)
        {
            var searchTerm = search.ToLower();

            IEnumerable<Employee> result;

            result = list.Where(x => x.FirstName.Contains(search));
            result = list.Where(x => x.LastName.Contains(search));
            result = list.Where(x => x.Department.Contains(search));

            List<Employee> returnResult = result.ToList();

            return returnResult;

        }

        public static List<Employee> HiredThisYear(this List<Employee> list)
        {
            var result = list.Where(x => x.HireDate > DateTime.Now.AddDays(-365)).ToList();
            return result;
        }
        public static Employee GetFirstFromDepartment(this List<Employee> list, string department)
        {
            var emp = list.Where(x => x.Department.ToLower() == department.ToLower()).FirstOrDefault();

            return emp;
        }
    }
}
