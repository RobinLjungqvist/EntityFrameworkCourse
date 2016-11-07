using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkProject;

namespace ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {

            }
            var control = new StudentControl();

            var students = control.GetAllStudents();


            Console.WriteLine("Students\n-----------------------------------------------");
            foreach (var s in students)
            {
                Console.WriteLine("Name: " + s.People.FirstName + " " + s.People.LastName);
                foreach (var g in s.Grades)
                {
                    Console.WriteLine("Course: " + g.Courses.CourseName + " Grade: " + g.Grade);
                    Console.WriteLine("--------------------------------------------------------");
                    
                    
                }
            }

            var peopleCtx = new PeopleControl();

            //var people = peopleCtx.GetAllPeople();


            //// Insert
            //peopleCtx.InsertPeople(new People() { FirstName = "Algot", LastName = "Alfredsson", Email = "AlleAlle@Email.com" });

            //people.ToList().ForEach(x => Console.WriteLine($"{x.Id} {x.FirstName} {x.LastName} {x.Email}"));

            //Delete
            //var input = Console.ReadLine();

            //var toDelete = peopleCtx.PeopleByID(int.Parse(input));

            //peopleCtx.RemovePeople(toDelete);

            //var newPeople = peopleCtx.GetAllPeople();

            //newPeople.ToList().ForEach(x => Console.WriteLine($"{x.Id} {x.FirstName} {x.LastName} {x.Email}"));

            //Update
            //Console.WriteLine("id: ");
            //var nameID = Console.ReadLine();
            //Console.WriteLine("New Name:");
            //var namechange = Console.ReadLine();

            //var nameChangePerson = peopleCtx.PeopleByID(int.Parse(nameID));

            //nameChangePerson.FirstName = namechange;

            //peopleCtx.UpdatePeople(nameChangePerson);

            //var newPeople2 = peopleCtx.GetAllPeople();

            //newPeople2.ToList().ForEach(x => Console.WriteLine($"{x.Id} {x.FirstName} {x.LastName} {x.Email}"));

            //Insert Student
            var ppl = new People() { FirstName = "Lisa", LastName = "Sävås", Email = "Lisa@Sävås.se" };
            peopleCtx.InsertPeople(ppl);

            var studentClass = new StudentClasses() { ClassName = "WIN15" };

            var studentClassesCtx = new ClassesControl();
            studentClassesCtx.InsertorUpdateClass(studentClass);

            

            var educationCTX = new EducationsControl();

            var education = new Educations() { EducationName = "Administration" };
            educationCTX.InsertorUpdateEducation(education);


            var newStudent = new Students() {
                PersonId = ppl.Id,
                StudentClass_Id = studentClass.Id,
                EducationId = education.Id
            };

            control.InsertStudent(newStudent);

            var newStudentContext = new StudentControl();
            var studentsList = newStudentContext.GetAllStudents().ToList();

            Console.WriteLine("Added new student Lisa");
            Console.WriteLine("-------Students Again-------");
            foreach (var stud in studentsList)
            {
                
                Console.WriteLine("Name: " + stud.People.FirstName + " " + stud.People.LastName);
                Console.WriteLine("CourseID: " + stud.StudentClasses.Id + " Class: " + stud.StudentClasses.ClassName);
                Console.WriteLine("ID: " + stud.Educations.Id + " Education Name: " + stud.Educations.EducationName);
                Console.WriteLine("--------------------------------------------------------------------------------");
            }

            var AttendanceControl = new AttendanceControl();

            Attendance att = new Attendance() { Date = new DateTime(2016,11,02), StudentID = newStudent.Id, CourseID = 2, Attendance1 = false };

            AttendanceControl.InsertAttendance(att);

            var lisa = newStudentContext.StudentsByID(newStudent.Id);

            var attendance = new AttendanceControl();

            var attendanceObj = attendance.AttendaceByStudentAndCourseID(newStudent.Id, 2);
            Console.WriteLine("Added new attendance for Lisa");
            Console.WriteLine("-----Attendance-----");
            Console.WriteLine($"{lisa.People.FirstName} {lisa.People.LastName} Närvaro i {attendanceObj.Courses.CourseName} den {attendanceObj.Date}: {attendanceObj.Attendance1}");
            Console.WriteLine();

            AttendanceControl.RemoveAttendance(att);
            //educationCTX.RemoveEducation(education);
            control.RemoveStudent(newStudent);
            studentClassesCtx.RemoveClass(studentClass);
            educationCTX.RemoveEducation(education);
            peopleCtx.RemovePeople(ppl);


            Console.ReadKey();
        }
    }
}
