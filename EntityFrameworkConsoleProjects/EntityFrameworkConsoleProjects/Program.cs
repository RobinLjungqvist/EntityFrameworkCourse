using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkConsoleProjects;

namespace FirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //How to add entity framework.

            // Manage NuGet packages and install Entity Framework.
            

            using (var context = new OrderSystemEntities())
            {
                var result = from x in context.tblCustomer
                             where x.tblCity.City.StartsWith("G")
                             select x;

                foreach (var customer in result)
                {
                    Console.WriteLine(customer.FirstName + " " + customer.LastName + " " + customer.tblCity.City);
                    foreach (var order in customer.tblOrder)
                    {
                        foreach (var product in order.tblOrder_Product)
                        {
                            Console.WriteLine(product.tblProduct.ProductName);
                        }
                    }
                }
            }
            Console.ReadKey();

            using(var context = new OrderSystemEntities())
            {
                var customer = new tblCustomer();
                customer.FirstName = "Robin";
                customer.LastName = "Ljungqvist";
                customer.MiddleName = "Erik Albin";
                customer.StreetAdress = "Pickolagränd 3";

                //Hämta ut CityID för GNOSJO.
                customer.CityID = context.tblCity.Where(c => c.City == "GNOSJO").Select(c => c.CityID).First();

                var postalcode = new tblPostalCode();


                // Lägga till en ny postalcode.
                postalcode.PostalCode = "33233";

                context.tblPostalCode.Add(postalcode);

                context.SaveChanges();

                // Plocka ut idt från en tabel.
                customer.PostalCodeID = context.tblPostalCode.Where(pc => pc.PostalCode == "33233").Select(pc => pc.PostalCodeID).First();
                context.tblCustomer.Add(customer);

                context.SaveChanges();

                var result = from x in context.tblCustomer
                             where x.FirstName.StartsWith("R")
                             select x;

                foreach (var user in result)
                {
                    Console.WriteLine(user.FirstName);
                }
            }
            Console.ReadKey();

        }
    }
}
