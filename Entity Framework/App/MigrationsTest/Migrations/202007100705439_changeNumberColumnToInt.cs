namespace MigrationsTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeNumberColumnToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "number", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "number", c => c.String());
        }
    }
}
