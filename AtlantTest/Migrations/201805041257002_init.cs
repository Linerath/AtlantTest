namespace AtlantTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomenclatureCode = c.String(),
                        Name = c.String(),
                        MyProperty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Storekeepers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Storekeepers");
            DropTable("dbo.Details");
        }
    }
}
