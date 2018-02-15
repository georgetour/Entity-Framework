using System.Collections.Generic;

namespace Loading_Related_Objects
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
