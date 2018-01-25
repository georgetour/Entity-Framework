using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.EntityConfigurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
           
                       Property(c => c.Name)
                       .IsRequired()
                       .HasMaxLength(255);

            //Change max length for Description in Courses
           
                        Property(c => c.Description)
                        .HasMaxLength(2000);

            //Change Courses foreign key Author_Id to AuthorId
            //And if an author has a course not let to be delete
           
                        HasRequired(c => c.Author)
                        .WithMany(a => a.Courses)
                        .HasForeignKey(c => c.AuthorId)
                        .WillCascadeOnDelete(false);

            //Change name of table TagCourses(was created in database automatically) to CoursesTag
           
                        HasMany(c => c.Tags)
                        .WithMany(c => c.Courses)
                        .Map(m =>
                        {
                            m.ToTable("CourseTags");
                            //Since we start from Course the left side is Course
                            //The name of the left key is going to be CourseId
                            m.MapLeftKey("CourseId");
                            //The name of the left key is going to be TagId
                            m.MapRightKey("TagId");
                        });

            //New table cover and relationship with Course
           
                        HasRequired(c => c.Cover)
                        .WithRequiredPrincipal(c => c.Course);

        }
    }
}
