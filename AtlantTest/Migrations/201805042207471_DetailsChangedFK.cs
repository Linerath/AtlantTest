namespace AtlantTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetailsChangedFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Details", "Storekeeper_Id", "dbo.Storekeepers");
            DropIndex("dbo.Details", new[] { "Storekeeper_Id" });
            AddColumn("dbo.Details", "StorekeeperId", c => c.Int(nullable: false));
            DropColumn("dbo.Details", "Storekeeper_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Details", "Storekeeper_Id", c => c.Int());
            DropColumn("dbo.Details", "StorekeeperId");
            CreateIndex("dbo.Details", "Storekeeper_Id");
            AddForeignKey("dbo.Details", "Storekeeper_Id", "dbo.Storekeepers", "Id");
        }
    }
}
