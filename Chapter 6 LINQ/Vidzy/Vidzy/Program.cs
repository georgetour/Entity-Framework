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

            //Action movies sorted by name
            var actionMovies = context.Videos
                .Where(v => v.Genre.Name == "action")
                .OrderBy(v => v.Name)
                .Select(v => new { VideoName = v.Name });
            Console.WriteLine("***Action Movies***");
            foreach (var movie in actionMovies)
            {

                Console.WriteLine(movie.VideoName);
            }
            Console.WriteLine();


            //Gold drama movies sorted by release date(newest first)
            var dramaMovies = context.Videos
                .Where(v => v.Genre.Name == "drama" && v.Classification == Classification.Gold)
                .OrderBy(v => v.ReleaseDate)
                .Select(v => new { VideoName = v.Name });

            Console.WriteLine("***Gold Drama Movies***");
            foreach (var movie in dramaMovies)
            {

                Console.WriteLine(movie.VideoName);
            }
            Console.WriteLine();


            //All movies projected into an anonymous type with two properties:
            //MovieName and Genre

            var allMovies = context.Videos
                .Select(v => new { MovieName = v.Name, Genre = v.Genre.Name });

            Console.WriteLine("***All Movies***");
            foreach (var movie in allMovies)
            {

                Console.WriteLine("Title: {0} Genre: {1}", movie.MovieName, movie.Genre);
            }

            Console.WriteLine();

            //All movies grouped by their classification

            //var moviesByClassification = context.Videos.GroupBy(v => v.Classification, v => v.Name);


            //foreach (var movie in moviesByClassification)
            //{
            //    Console.WriteLine("Movie classification: "+ movie.Key);
            //    foreach(var name in movie)
            //    {
            //        Console.WriteLine(name);
            //    }

            //}

            Console.WriteLine("***All movies grouped by their classification***");
            var moviesByClassification = context.Videos.GroupBy(v => v.Classification)
                .Select(v => new { Classification = v.Key, Movies = v.OrderBy(g=> g.Name) });

            foreach (var v in moviesByClassification)
            {
                Console.WriteLine("Classification: "+ v.Classification);
                foreach (var movie in v.Movies)
                {
                    Console.WriteLine("Title: " + movie.Name);
                }
                Console.WriteLine();
            }


            //List of classifications sorted alphabetically and count of videos in them.
            Console.WriteLine("***List of classifications sorted alphabetically and count of videos in them***");
            var videosInClassifications = context.Videos
                .GroupBy(v => v.Classification)
                .OrderBy(c => c.Key.ToString());

            foreach (var video in videosInClassifications)
            {
                
                Console.WriteLine("Classification: {0}  Total videos: {1}",video.Key, video.Count());
            }

            Console.WriteLine();

            //Better solution
            //var classifications = context.Videos
            //   .GroupBy(v => v.Classification)
            //   .Select(g => new
            //   {
            //       Name = g.Key.ToString(),
            //       VideosCount = g.Count()
            //   })
            //   .OrderBy(c => c.Name);

            //Console.WriteLine();
            //Console.WriteLine("CLASSIFICATIONS AND NUMBER OF VIDEOS IN THEM");
            //foreach (var c in classifications)
            //    Console.WriteLine("{0} ({1})", c.Name, c.VideosCount);



            //List of genres and number of videos they include, sorted by the number
            //of videos

            Console.WriteLine("***List of genres and number of videos they include, sorted by the numberof videos ***");
            var videosInGenres = context.Genres
                .GroupJoin(context.Videos, g => g.Id, v => v.GenreId, (genre, videos) =>
                  new
                  {
                      Name = genre.Name,
                      VideosCount = videos.Count()
                  })
                .OrderByDescending(g => g.VideosCount);
                
            foreach (var g in videosInGenres)
            {
                Console.WriteLine(g.Name);
                Console.WriteLine(g.VideosCount);
            }


        }
    }
}
