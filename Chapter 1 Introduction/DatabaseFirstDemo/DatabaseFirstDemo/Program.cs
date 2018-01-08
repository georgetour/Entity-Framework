using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Access the Db context
            var context = new DatabaseFirstDemoEntities();

            //Create new post
            var post = new Post()
            {
                Body = "Μπομπ2",
                DatePublished = DateTime.Now,
                Title = "Title2"
                
            };

            //Add post to memory
            context.Posts.Add(post);

            //Add post to db by saving changes
            context.SaveChanges();


        }
    }
}
