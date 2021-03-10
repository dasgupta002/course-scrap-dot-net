namespace tutorialspoint_test_API_framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.offices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        location = c.String(nullable: false),
                        employeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.employees", t => t.employeeID, cascadeDelete: true)
                .Index(t => t.employeeID);
            
            CreateTable(
                "dbo.updatedOffices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        location = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.offices", "employeeID", "dbo.employees");
            DropIndex("dbo.offices", new[] { "employeeID" });
            DropTable("dbo.updatedOffices");
            DropTable("dbo.offices");
            DropTable("dbo.employees");
        }
    }
}
