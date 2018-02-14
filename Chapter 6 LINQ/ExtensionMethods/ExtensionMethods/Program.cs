using System.Linq;
using System;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            //Projection
            var coursesLevel1 = context.Courses
                .Where(c => c.Level == 1).OrderByDescending(c=> c.Name)
                .ThenByDescending(c=> c.Level)
                .Select(c=> new { CourseName =c.Name , AuthorName = c.Author.Name });

            Console.WriteLine("******Projection******** \n");

            foreach (var result in coursesLevel1)
            {
                Console.WriteLine(result.CourseName);
                Console.WriteLine(result.AuthorName);
            }
            Console.WriteLine();

            //IQueryable is simply a list inside a list so we need a forach inside foreach
            var coursesTags = context.Courses
                .Where(c => c.Level == 1).OrderByDescending(c => c.Name)
                .ThenByDescending(c => c.Level)
                .Select(c => c.Tags );
            Console.WriteLine("*****Course Tags with foreach inside foreach****** \n");
            foreach (var c in coursesTags)
            {
                foreach (var tag in c)
                {

                    Console.WriteLine(tag.Name);
                }
            }
            Console.WriteLine();
            //To fix the above
            var tags = context.Courses
                .Where(c => c.Level == 1).OrderByDescending(c => c.Name)
                .ThenByDescending(c => c.Level)
                .SelectMany(c => c.Tags);
            Console.WriteLine("*****Course Tags with SelectMany***** \n");
            foreach (var t in tags)
            {
                
                    Console.WriteLine(t.Name);
                
            }
            Console.WriteLine();

            //Make unique result with Distinct
            var uniqueTags = context.Courses
                .Where(c => c.Level == 1).OrderByDescending(c => c.Name)
                .ThenByDescending(c => c.Level)
                .SelectMany(c => c.Tags)
                .Distinct();
            Console.WriteLine("*****Unique Tags with SelectMany and Distinct ***** \n");
            foreach (var t in uniqueTags)
            {
                Console.WriteLine(t.Name);
            }
            Console.WriteLine();


            //GroupBy
            var groups = context.Courses.GroupBy(c => c.Level);

            Console.WriteLine("*****Grouping and GroupBy ***** \n");

            foreach (var group in groups)
            {
                Console.WriteLine("Key: " + group.Key);
                foreach (var course in group)
                {
                    Console.WriteLine("\t"+course.Name);
                }
            }
            Console.WriteLine();


            //Inner Join
            //We are usingCourses with Authors with their Id and we get the course name and author name
            var courses = context.Courses.Join(context.Authors, 
                c => c.AuthorId, 
                a => a.Id, 
                (course, author) => new
                {
                    CourseName = course.Name,
                    AuthorName = author.Name
                });

            Console.WriteLine("*****Inner Join ***** \n");

            foreach (var course in courses)
            {
                Console.WriteLine("Course: "+ course.CourseName);
                Console.WriteLine("Author: " +course.AuthorName); 
            }
            Console.WriteLine();


            //All authors and count their courses with GroupJoin
            var coursesForAuthors= context.Authors.GroupJoin(context.Courses, a => a.Id, c => c.AuthorId, (author, allCourses) => new
            {
                AuthorName = author.Name,
                Courses = allCourses.Count()

            });

            Console.WriteLine("*****GroupJoin ***** \n");

            foreach (var course in coursesForAuthors)
            {
                Console.WriteLine("{0} has {1} courses",course.AuthorName,course.Courses);
            }
            Console.WriteLine();


            //Cross Join
            //Give all authors all courses
            var allCoursesToAuthors = context.Authors.SelectMany(a => context.Courses, (author, course) => new
            {

                AuthorName = author.Name,
                CourseName = course.Name
            });

            //Partitioning

            Console.WriteLine("*****Partitioning ***** \n");

            var limitResults = context.Courses.OrderBy(c => c.Name).Skip(5).Take(10);

            foreach (var item in limitResults)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();


            //Element Operators

            Console.WriteLine("*****Element Operators ***** \n");
            //First course that it's price is bigger than 20 
            var firstCourse = context.Courses.OrderBy(c => c.Name).FirstOrDefault(c => c.FullPrice >10);

            Console.WriteLine(firstCourse.Name);

            var singleCourse = context.Courses.Single(c => c.Id == 1);

            Console.WriteLine(singleCourse.Name);

            Console.WriteLine();


            //Quanitfying

            Console.WriteLine("*****Qualifying ***** \n");

            var expensiveCourses = context.Courses.All(c => c.FullPrice > 20);

            Console.WriteLine(expensiveCourses);

            var anyCoursesAbove30 = context.Courses.Any(c => c.FullPrice > 30);

            Console.WriteLine(anyCoursesAbove30);

            Console.WriteLine();


            //Aggregating

            Console.WriteLine("*****Aggregating ***** \n");

            var countAllCourses = context.Courses.Count(c=>c.FullPrice >100);

            Console.WriteLine("We have {0} total courses above 100$",countAllCourses);

            Console.WriteLine();

            var mostExpensiveCourse = context.Courses.Max(c=> c.FullPrice);

            Console.WriteLine("Most expensive price "+mostExpensiveCourse);

            var cheapestCourse = context.Courses.Min(c => c.FullPrice);

            Console.WriteLine("Cheapest price "+ cheapestCourse);

            var averageCoursePrice = context.Courses.Average(c => c.FullPrice);

            Console.WriteLine("The average of all courses is " + averageCoursePrice);



        }
    }
}
