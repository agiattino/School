using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new DataContext();

            // Show a list of all the students
            Console.WriteLine("List all Students in Student table");
            var allStudent = database.Students.ToList();
            foreach (var Student in allStudent)
            {

                Console.Write($"{Student.Id} : {Student.FirstName} : {Student.LastName} : {Student.Age} :{Student.ClassOf}");
            }

            // Given a student's name, show their grades
            //var allGrades = database.Grades.ToList();

            var StuNameAndGradeResult = database.Students.Join(database.Grades, 
                                        s1 =>  s1.Id, 
                                        g2 =>  g2.StudentId, 

                                        (s1, g2) => new
                                        {   Student_LName = s1.LastName,
                                            Student_FName = s1.FirstName,
                                            Student_Course = g2.CourseName,
                                            Student_Grades = g2.grade
                                        } );

            // Display StuNameAndGradeResult
            Console.WriteLine("Student Name And Grade Result: ");
            foreach (var val in StuNameAndGradeResult)
            {
                Console.WriteLine($"{val.Student_LName} : {val.Student_FName} : {val.Student_Grades}" );
            }



            // foreach(var val in query) {
            // Console.WriteLine("Student Last Name : {0}   CourseName : {1}    Grade: {2}",
            //                 val.StudentName, val.StudentCourse, val.StudentGrade  ) ;           
            // }






            var xxGPA  = from s1 in database.Students  
                         join j1 in database.Grades on s1.Id equals j1.StudentId
                         group  j1 by s1.LastName into groupies 
                         select new { sName= groupies.Key,
                                      GPA = groupies.Average(x  => x.grade) } ;                                     
           
                                                           
 
            foreach(var val in xxGPA) {
                Console.WriteLine(val);
            }                  





            // Console.WriteLine("Hello World!");
        }
    }
}
