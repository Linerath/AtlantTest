namespace AtlantTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetailsChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Details", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Details", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Details", "DeleteDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Details", "Storekeeper_Id", c => c.Int());
            CreateIndex("dbo.Details", "Storekeeper_Id");
            AddForeignKey("dbo.Details", "Storekeeper_Id", "dbo.Storekeepers", "Id");
            DropColumn("dbo.Details", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Details", "MyProperty", c => c.Int(nullable: false));
            DropForeignKey("dbo.Details", "Storekeeper_Id", "dbo.Storekeepers");
            DropIndex("dbo.Details", new[] { "Storekeeper_Id" });
            DropColumn("dbo.Details", "Storekeeper_Id");
            DropColumn("dbo.Details", "DeleteDate");
            DropColumn("dbo.Details", "CreationDate");
            DropColumn("dbo.Details", "Quantity");
        }
    }
}
