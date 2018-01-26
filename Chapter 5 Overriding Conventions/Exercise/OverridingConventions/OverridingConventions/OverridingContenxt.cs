namespace OverridingConventions
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using EntityConfigurations;

    public partial class OverridingContenxt : DbContext
    {
        public OverridingContenxt()
            : base("name=OverridingContenxt")
        {
        }

        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new VideoConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Videos)
                .WithOptional(e => e.Genre)
                .HasForeignKey(e => e.Genre_Id);
        }
    }
}
