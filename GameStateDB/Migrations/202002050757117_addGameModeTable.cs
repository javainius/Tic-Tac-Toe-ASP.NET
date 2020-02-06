namespace TicTacDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGameModeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameMode",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameMode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GameMode");
        }
    }
}
