using System.Data.Entity;
using System.Linq;
using System;
using System.Collections;

namespace Vidzy
{
    class Program
    {
        private static object group;

        static void Main(string[] args)
        {
            var context = new VidzyContext();

            //Lazy Loading
            //var videos = context.Videos.ToList();

            //foreach (var video in videos)
            //{
            //    Console.WriteLine(video.Name);
            //    Console.WriteLine(video.Genre.Name);
            //}

            //Eager loading
            var videos = context.Videos.Include(v => v.Genre).ToList();

            foreach (var video in videos)
            {
                Console.WriteLine(video.Name);
                Console.WriteLine(video.Genre.Name);
            }

        }
    }
}
