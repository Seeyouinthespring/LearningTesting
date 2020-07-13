namespace MigrationsTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addScoresForMatches : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "homeScore", c => c.Int(defaultValue: 0));
            AddColumn("dbo.Matches", "guestScore", c => c.Int(defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matches", "guestScore");
            DropColumn("dbo.Matches", "homeScore");
        }
    }
}
