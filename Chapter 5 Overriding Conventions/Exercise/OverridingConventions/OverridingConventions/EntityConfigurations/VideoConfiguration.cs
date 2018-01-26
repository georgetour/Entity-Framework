using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverridingConventions.EntityConfigurations
{
    class VideoConfiguration : EntityTypeConfiguration<Video>
    {
        public VideoConfiguration()
        {
            Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(v => v.Genre_Id)
                .HasColumnName("Genre");

            Property(v => v.Classification)
                .HasColumnType("tinyint");

            HasMany(v => v.Tags)
                .WithMany(v => v.Videos)
                .Map(m =>
                {
                    m.ToTable("VideoTags");
                    m.MapLeftKey("VideoOld");
                    m.MapRightKey("TagId");

                });
        }
    }
}
