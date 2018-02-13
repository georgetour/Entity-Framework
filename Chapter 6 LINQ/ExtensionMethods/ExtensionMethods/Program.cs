using System.Linq;
using System;

namespace IQueryableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            IQueryable<Course> courses = context.Courses;

            var filtered = courses.Where(c => c.Level == 1);

            foreach (var course in filtered)
            {
                Console.WriteLine(course.Name);
            }


        }
    }
}
