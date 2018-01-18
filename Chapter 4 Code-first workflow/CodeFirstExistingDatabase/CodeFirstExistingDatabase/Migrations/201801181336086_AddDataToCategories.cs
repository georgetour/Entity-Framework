namespace CodeFirstExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Name) VALUES ('Web Development')");
            Sql("INSERT INTO Categories (Name) VALUES ('NET Framework')");
        }
        
        public override void Down()
        {
        }
    }
}
