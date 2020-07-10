namespace MigrationsTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCityFieldForUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "city", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "city");
        }
    }
}
