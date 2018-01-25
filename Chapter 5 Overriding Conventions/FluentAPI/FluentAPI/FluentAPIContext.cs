using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            modelBuilder.Entity<Course>()
                       .Property(c => c.Name)
                       .IsRequired()
                       .HasMaxLength(255);

            //Change max length for Description in Courses
            modelBuilder.Entity<Course>()
                        .Property(c => c.Description)
                        .HasMaxLength(2000);

            //Change Courses foreign key Author_Id to AuthorId
            //And if an author has a course not let to be delete
            modelBuilder.Entity<Course>()
                        .HasRequired(c => c.Author)
                        .WithMany(a => a.Courses)
                        .HasForeignKey(c => c.AuthorId)
                        .WillCascadeOnDelete(false);

            //Change name of table TagCourses(was created in database automatically) to CoursesTag
            modelBuilder.Entity<Course>()
                        .HasMany(c => c.Tags)
                        .WithMany(c => c.Courses)
                        .Map(m => m.ToTable("CourseTags"));

            //New table cover and relationship with Course
            modelBuilder.Entity<Course>()
                        .HasRequired(c => c.Cover)
                        .WithRequiredPrincipal(c => c.Course);


            base.OnModelCreating(modelBuilder);
        }

    }
}
