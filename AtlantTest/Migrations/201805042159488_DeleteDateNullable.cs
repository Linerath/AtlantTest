namespace AtlantTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Details", "DeleteDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Details", "DeleteDate", c => c.DateTime(nullable: false));
        }
    }
}
