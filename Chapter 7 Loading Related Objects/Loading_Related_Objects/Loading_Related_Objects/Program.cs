using System.Linq;
using System;
using System.Data.Entity;

namespace Loading_Related_Objects
{
    class Program
    {
        static void Main(string[] args)
        {

            var context = new PlutoContext();

            #region Lazy Loading

            Console.WriteLine("Lazy loading");

            //It creates a query in database immediately
            //This course object has not its tags initialized
            var courses = context.Courses.Single(c => c.Id == 2);

            //When we get in here and we access course.Tags entitty framework will send another query 
            //for the tags for this course
            foreach (var tag in courses.Tags)
            {
                Console.WriteLine(tag.Name);
            }

            Console.WriteLine();

            #endregion


            #region N + 1

            Console.WriteLine("N + 1");

            //We have one query here
            var courses2 = context.Courses.ToList();

            //Here though for Author.Name enity framework is going to run a seperate query to get the Author for
            //tha course
            //So we assume we have N courses we will get N + 1(which is the first query above)
            foreach (var course in courses2)
            {
                Console.WriteLine("{0} by {1}", course.Name, course.Author.Name);
            }

            Console.WriteLine();


            #endregion


            #region Eager Loading

            //We can resolve this N + 1 by loading all the courses and their authors
            Console.WriteLine("Eager Loading");

            //Include has two overloads(one takes a string and the other a lambda expression)
            //With this query entity framework will join the courses table with authors table
            //to eager load all the courses and their authors
            //Wrong practices
            //var courses3 = context.Courses.Include("Author").ToList();

            //Correct with lambda expression
            var courses3 = context.Courses.Include(c => c.Author).ToList();

            foreach (var course in courses3)
            {
                Console.WriteLine("{0} by {1}", course.Name, course.Author.Name);
            }


            Console.WriteLine();

            #endregion


            #region Explicit Loading

            Console.WriteLine("Explicit Loading");

            //First query get an author with id 1
            var author2 = context.Authors.Single(a => a.Id == 1);

            //MSDN way
            //You have to remember more of DbContext API
            //This only works for single entries and NOT a list of objects
            context.Entry(author2).Collection(a => a.Courses).Query().Where(c => c.FullPrice == 0).Load();

            //Better way
            context.Courses.Where(c => c.AuthorId == author2.Id && c.FullPrice == 49).Load();

           
            Console.WriteLine();

            Console.WriteLine("Free Courses");
            var authors2 = context.Authors.ToList();

            //Select all authors ids
            var authorIds= authors2.Select(a => a.Id);

            
            Console.WriteLine();

            #endregion

        }
    }
}
