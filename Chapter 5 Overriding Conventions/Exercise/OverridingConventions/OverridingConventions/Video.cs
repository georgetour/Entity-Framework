namespace OverridingConventions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Video
    {
        public Video()
        {
            Tags = new HashSet<Tag>();
        }


        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int? Genre_Id { get; set; }

        public byte Classification { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

    }
}
