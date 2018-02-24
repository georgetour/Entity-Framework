
using System;
using System.Linq;
using System.Data.Entity;

namespace Vidzy
{
    class Program
    {

        

        static void Main(string[] args)
        {
            AddTagToVideo(1, "classics", "drama", "comedy");

        }

        public static void AddVideo(string name, byte genreId, DateTime releaseDate, Classification classification)
        {
            using (var context = new VidzyContext())
            {
                var video = new Video
                {
                    Name = name,
                    GenreId = genreId,
                    ReleaseDate = releaseDate,
                    Classification = classification
                };
                
                context.Videos.Add(video);
                context.SaveChanges();
                Console.WriteLine("Video was added to db");
            }
        }

        public static void AddTag(string name)
        {
            using (var context = new VidzyContext())
            {
                var tags = context.Tags;

                //Check if record exists
                bool tagExists = context.Tags.Any(t => t.Name.Equals(name));

                if (tagExists)
                {
                    Console.WriteLine("Record exists");
                    return;
                }
                else
                {
                    var tag = new Tag { Name = name };
                    context.Tags.Add(tag);
                    context.SaveChanges();
                    Console.WriteLine("Record was added");
                }
            }
        }


        public static void AddTagToVideo(int videoID,params string[] tagNames)
        {
            using (var context = new VidzyContext())
            {
                //First bring all tags to list according to tagNames
                var tags = context.Tags.Where(t => tagNames.Contains(t.Name)).ToList();

                //Check for duplicates tags and if it doesn't exist create new
                bool tagExists;
                foreach (var tagName in tagNames)
                {
                    tagExists =  tags.Any(t => t.Name.Equals(tagName));

                    if (!tagExists)
                    {
                        tags.Add(new Tag { Name = tagName });
                    }
                    
                }


                var video = context.Videos.SingleOrDefault(v => v.Id == videoID);
                tags.ForEach(t => video.AddTag(t));

                context.SaveChanges();

            }
        
        }




    }
}
