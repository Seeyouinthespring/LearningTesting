namespace MigrationsTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTypesInTournament : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tournaments", "name", c => c.String());
            AlterColumn("dbo.Tournaments", "prizepool", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tournaments", "prizepool", c => c.Int(nullable: false));
            AlterColumn("dbo.Tournaments", "name", c => c.Int(nullable: false));
        }
    }
}
