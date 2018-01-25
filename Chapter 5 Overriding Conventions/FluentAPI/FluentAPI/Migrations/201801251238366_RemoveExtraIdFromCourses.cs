namespace FluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveExtraIdFromCourses : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Courses", new[] { "Author_Id1" });
            DropColumn("dbo.Courses", "Author_Id");
            RenameColumn(table: "dbo.Courses", name: "Author_Id1", newName: "Author_Id");
            AlterColumn("dbo.Courses", "Author_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Author_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Courses", new[] { "Author_Id" });
            AlterColumn("dbo.Courses", "Author_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Courses", name: "Author_Id", newName: "Author_Id1");
            AddColumn("dbo.Courses", "Author_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "Author_Id1");
        }
    }
}
