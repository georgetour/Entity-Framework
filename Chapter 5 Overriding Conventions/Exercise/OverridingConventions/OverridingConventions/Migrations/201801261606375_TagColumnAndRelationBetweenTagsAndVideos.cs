namespace OverridingConventions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagColumnAndRelationBetweenTagsAndVideos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        VideoOld = c.String(),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.VideoTags",
                c => new
                    {
                        VideoOld = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VideoOld, t.TagId })
                .ForeignKey("dbo.Videos", t => t.VideoOld, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.VideoOld)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.VideoTags", "VideoOld", "dbo.Videos");
            DropIndex("dbo.VideoTags", new[] { "TagId" });
            DropIndex("dbo.VideoTags", new[] { "VideoOld" });
            DropTable("dbo.VideoTags");
            DropTable("dbo.Tags");
        }
    }
}
