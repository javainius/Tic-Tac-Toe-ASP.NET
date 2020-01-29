namespace TicTacDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grid",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstColumn = c.String(),
                        SecondColumn = c.String(),
                        ThirdColumn = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Grid");
        }
    }
}
