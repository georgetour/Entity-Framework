using System.Linq;
using System;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            //LINQ SYNTAX
            var query =
                from c in context.Courses
                where c.Name.Contains("c#")
                orderby c.Name
                select c;

            //foreach (var course in query)
            //{
            //    Console.WriteLine("C# related courses are :" + course.Name);
            //}
            //Console.WriteLine();

            //Restriction operator where
            var query2 =
                from c in context.Courses
                where c.Level == 1 && c.Author.Id == 1
                select c;

            //Ordering by Level and then Name
            var query3 =
                from c in context.Courses
                where c.Author.Id == 1
                orderby c.Level descending, c.Name
                select c;

            //Projection
            var query4 =
                from c in context.Courses
                where c.Author.Id == 1
                orderby c.Level descending, c.Name
                select new { Name = c.Name, Author = c.Author.Name };


            //Group courses by level
            var query5 =
                from c in context.Courses
                group c by c.Level into g
                select g;

            //foreach (var group in query5)
            //{
            //    Console.WriteLine("{0} {1}",group.Key,group.Count());

            //    foreach (var course in group)
            //    {
            //        Console.WriteLine("\t{0}",course.Name);
            //    }
            //}

            //Inner join 
            var query6 =
                from c in context.Courses
                join a in context.Authors on c.AuthorId equals a.Id
                select new { CourseName = c.Name, AuthorName = a.Name };

            foreach (var course in query6)
            {
                Console.WriteLine(course.CourseName);
                Console.WriteLine(course.AuthorName);
            }

            //Group join
            //How many courses each author has 
            var query7 =
                from a in context.Authors
                join c in context.Courses on a.Id equals c.AuthorId into g
                select new { AuthorName = a.Name, Courses = g.Count() };

            //foreach (var x in query7)
            //{
            //    Console.WriteLine("{0} {1}",x.AuthorName,x.Courses);
                
            //}

            //Cross join
            //A combination of every author and every courses
            var query8 =
                from a in context.Authors
                from c in context.Courses
                select new { AuthorName = a.Name, CourseName = c.Name };

            //foreach (var x in query8)
            //{
            //    Console.WriteLine("{0} {1}", x.AuthorName, x.CourseName);

            //}


            //Extension methods
            var courses = context.Courses
                .Where(c => c.Name
                .Contains("c#"))
                .OrderBy(c => c.Name);

            //foreach (var course in courses)
            //{
            //    Console.WriteLine("C# related courses are :" + course.Name);
            //}



        }
    }
}
