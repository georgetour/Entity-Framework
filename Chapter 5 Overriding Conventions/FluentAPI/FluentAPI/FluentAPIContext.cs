using FluentAPI.EntityConfigurations;
using System.Data.Entity;

namespace FluentAPI
{
    public class FluentAPIContext :DbContext
    {
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfiguration());
        }

    }
}
