using System.Linq;
using System;

namespace DeferredExecution
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            //var allBeginnerCourses = context.Courses.Where(c => c.isBeginnerCourse == true);

            ////Throws invalid error exception
            ////This is because isBeginnerCourse is a custom property and LINQ doesn;t know how 
            ////to translate it to SQL
            //foreach (var course in allBeginnerCourses)
            //{
            //    Console.WriteLine(course.Name);
            //}

            //To fix it we use immediate execution.This though has an impact in our application since we load all our courses from the database just to filter them in memory.In smaller applications it isn't noticeable.

            var allBeginnerCourses = context.Courses.ToList().Where(c => c.isBeginnerCourse == true);
            Console.WriteLine();
            Console.WriteLine("Immediate Execution");
            foreach (var course in allBeginnerCourses)
            {
                Console.WriteLine(course.Name);
            }



        }
    }
}
