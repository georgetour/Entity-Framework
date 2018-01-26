namespace OverridingConventions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VideoTableColumnsChanges : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Videos", name: "Genre_Id", newName: "Genre");
            RenameIndex(table: "dbo.Videos", name: "IX_Genre_Id", newName: "IX_Genre");
            AlterColumn("dbo.Videos", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Videos", "Classification", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Videos", "Classification", c => c.Int(nullable: false));
            AlterColumn("dbo.Videos", "Name", c => c.String());
            RenameIndex(table: "dbo.Videos", name: "IX_Genre", newName: "IX_Genre_Id");
            RenameColumn(table: "dbo.Videos", name: "Genre", newName: "Genre_Id");
        }
    }
}
