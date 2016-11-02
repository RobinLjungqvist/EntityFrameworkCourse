using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_6
{
    class Program
    {
        static void Main(string[] args)
        {
            #region DisplayStudents
            using (var ctx = new SchoolContext())
            {

                var students = ctx.Students.Include(x => x.Enrollments.Select(c=>c.Course));

                foreach (var student in students)
                {

                    Console.WriteLine("ID: " + student.ID + " Name: " + student.FirstMidName + " " + student.LastName);
                    foreach(var enroll in student.Enrollments)
                    {
                        Console.WriteLine($"Enrollment name: {enroll.Name}  CourseName: {enroll.Course.Name} Grade: {enroll.Grade}");
                    }
                    Console.WriteLine("-----------------------------------------------");

                }

            }
            #endregion

            using (var ctx = new SchoolContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;

                while (true)
                {
                    Console.WriteLine("Please enter a name to search for: ");
                    var searchTerm = Console.ReadLine();

                    var student = ctx.Students.Where(x => x.FirstMidName.StartsWith(searchTerm)).FirstOrDefault();/*.Include(x => x.Enrollments.Select(c => c.Course)).FirstOrDefault();*/


                    if (student != null)
                    {

                        Console.WriteLine($"ID: {student.ID} Name: {student.FirstMidName} {student.LastName}");
                        Console.WriteLine("--------------------------------------------------------");
                        ctx.Entry(student).Collection(x => x.Enrollments).Load();
                        foreach (var enrollment in student.Enrollments)
                        {
                            ctx.Entry(enrollment).Reference(x => x.Course).Load();
                            Console.WriteLine($"Enrollment in {enrollment.Name} id: {enrollment.ID}\nCourse: {enrollment.Course.Name} Course ID: {enrollment.Course.ID} Grade: {enrollment.Grade}");
                            Console.WriteLine("--------------------------------------------------------");
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No user was found with that name.");
                    } 
                }

            }

            Console.ReadKey();

        }



        public void CreateKalle()
        {
            using (var ctx = new SchoolContext())
            {
                Course kurs = new Course();
                kurs.Name = "Webbutveckling";
                kurs.Credits = 100;
                ctx.Courses.Add(kurs);
                ctx.SaveChanges();



                Enrollment enroll = new Enrollment();
                enroll.Name = "Webb-Utvecklare 2015";
                enroll.Grade = " IG - MVG";
                enroll.Course = kurs;

                ctx.Enrollments.Add(enroll);
                ctx.SaveChanges();





                Student stud = new Student("Blomkvist", "Kalle", new DateTime(2015, 01, 15, 16, 23, 1));
                stud.Enrollments.Add(enroll);
                ctx.Students.Add(stud);
                ctx.SaveChanges();



            }
        }
    }
}
