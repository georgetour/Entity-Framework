namespace VidzyExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenresAndVideosData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Action'),('Comedy'),('Horror'),('Thriller'),('Drama')");
        }
        
        public override void Down()
        {
        }
    }
}
