namespace OverridingConventions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreTableColumnNameRequiredAndMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String());
        }
    }
}
