using System.Linq;
using System;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();


            //For WPF apps
            var authors = context.Authors.ToList();

            var author = context.Authors.Single(a => a.Id == 1);

            var course = new Course
            {
                Name = "New Course 2",
                Description = "New Description 2",
                FullPrice = 20.50f,
                Level = 1,
                Author = author
            };

            //context.Courses.Add(course);

            //For Web apps

            var course2 = new Course
            {
                Name = "New Course 3",
                Description = "New Description 3",
                FullPrice = 20.50f,
                Level = 1,
                AuthorId = 1
            };

            //context.Courses.Add(course2);

            

            //Updating object
            var course3 = context.Courses.Find(4);// Single (c => c.Id == 12)
            course3.Name = "Changed Name";
            course3.AuthorId = 1;


            //context.SaveChanges();

        }
    }
}
