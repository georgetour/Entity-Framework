using System.Linq;
using System;
using System.Data.Entity;

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

            //Deleting a course with cascade delete on
            var course4 = context.Courses.Find(11);
            //context.Courses.Remove(course4);

            //context.SaveChanges();

            //Deleting an author with cascade delete off
            //Won't work will throw an error since we must delete 
            //var author2 = context.Authors.Find(6);
            //context.Authors.Remove(author2);

            //var author2 = context.Authors.Include(a => a.Courses).Single(a => a.Id == 2);
            //context.Courses.RemoveRange(author2.Courses);
            //context.Authors.Remove(author2);

            //context.SaveChanges();

            var entries = context.ChangeTracker.Entries<Author>();

            foreach (var item in entries)
            {
                Console.WriteLine(item.State);
            }

        }
    }
}
