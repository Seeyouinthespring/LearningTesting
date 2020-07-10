namespace MigrationsTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPlayersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fullname = c.String(),
                        number = c.String(),
                        birthdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Players");
        }
    }
}
