using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstProject
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var dbContext = new PlutoDbContext();

            //Get courses info from database
            var courses = dbContext.GetCourses();
            foreach (var course in courses)
            {
                Console.WriteLine("CourseId: "+ course.CourseID);
                Console.WriteLine("Course Title: " + course.Title);
                Console.WriteLine("Course Description: " + course.Description);
                
            }

        }
    }
}
