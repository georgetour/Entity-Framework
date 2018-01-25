namespace FluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectionBetweenTagAndCourses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Tags", new[] { "Course_Id" });
            CreateTable(
                "dbo.TagCourses",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Course_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Course_Id);
            
            DropColumn("dbo.Tags", "Course_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "Course_Id", c => c.Int());
            DropForeignKey("dbo.TagCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.TagCourses", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagCourses", new[] { "Course_Id" });
            DropIndex("dbo.TagCourses", new[] { "Tag_Id" });
            DropTable("dbo.TagCourses");
            CreateIndex("dbo.Tags", "Course_Id");
            AddForeignKey("dbo.Tags", "Course_Id", "dbo.Courses", "Id");
        }
    }
}
