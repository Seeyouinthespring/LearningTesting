namespace MigrationsTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMatchesTableAndLinkWithTeams : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        start = c.DateTime(nullable: false),
                        locationCity = c.String(nullable: false),
                        arena = c.String(nullable: false),
                        homeTeamId = c.Int(nullable: false),
                        guestTeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Teams", t => t.homeTeamId, cascadeDelete: false)
                .ForeignKey("dbo.Teams", t => t.guestTeamId, cascadeDelete: false)
                .Index(t => t.homeTeamId)
                .Index(t => t.guestTeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "guestTeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "homeTeamId", "dbo.Teams");
            DropIndex("dbo.Matches", new[] { "guestTeamId" });
            DropIndex("dbo.Matches", new[] { "homeTeamId" });
            DropTable("dbo.Matches");
        }
    }
}
