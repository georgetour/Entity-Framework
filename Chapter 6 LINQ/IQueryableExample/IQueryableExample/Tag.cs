using System.Collections.Generic;

namespace IQueryableExample
{
    public class Tag
    {
        public Tag()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
