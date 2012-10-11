namespace BenzinStationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PetrolStations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        Number = c.String(),
                        PostalCode = c.String(),
                        City = c.String(),
                        Location = c.Geography(),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.PetrolPrices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Unleaded92 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unleader95 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Diesel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartTime = c.DateTime(nullable: false),
                        PetrolStation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PetrolStations", t => t.PetrolStation_Id)
                .Index(t => t.PetrolStation_Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        HomePage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.PetrolPrices", new[] { "PetrolStation_Id" });
            DropIndex("dbo.PetrolStations", new[] { "Company_Id" });
            DropForeignKey("dbo.PetrolPrices", "PetrolStation_Id", "dbo.PetrolStations");
            DropForeignKey("dbo.PetrolStations", "Company_Id", "dbo.Companies");
            DropTable("dbo.Companies");
            DropTable("dbo.PetrolPrices");
            DropTable("dbo.PetrolStations");
        }
    }
}
