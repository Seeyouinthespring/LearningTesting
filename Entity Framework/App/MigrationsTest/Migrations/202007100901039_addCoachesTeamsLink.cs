namespace MigrationsTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCoachesTeamsLink : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Coaches");
            AlterColumn("dbo.Coaches", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Coaches", "Id");
            CreateIndex("dbo.Coaches", "Id");
            AddForeignKey("dbo.Coaches", "Id", "dbo.Teams", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coaches", "Id", "dbo.Teams");
            DropIndex("dbo.Coaches", new[] { "Id" });
            DropPrimaryKey("dbo.Coaches");
            AlterColumn("dbo.Coaches", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Coaches", "Id");
        }
    }
}
