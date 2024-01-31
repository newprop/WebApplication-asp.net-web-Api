namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(maxLength: 250),
                        Email = c.String(maxLength: 50),
                        DesignationId = c.Int(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Permanent = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                        Comapany = c.String(),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(maxLength: 20),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Experiences", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropIndex("dbo.Experiences", new[] { "EmployeeID" });
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropTable("dbo.UserInfoes");
            DropTable("dbo.Experiences");
            DropTable("dbo.Employees");
            DropTable("dbo.Designations");
        }
    }
}
