namespace BenzinStationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCompany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PetrolStations", "Company_Id", "dbo.Companies");
            DropIndex("dbo.PetrolStations", new[] { "Company_Id" });
            RenameColumn(table: "dbo.PetrolStations", name: "Company_Id", newName: "CompanyId");
            AddForeignKey("dbo.PetrolStations", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
            CreateIndex("dbo.PetrolStations", "CompanyId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PetrolStations", new[] { "CompanyId" });
            DropForeignKey("dbo.PetrolStations", "CompanyId", "dbo.Companies");
            RenameColumn(table: "dbo.PetrolStations", name: "CompanyId", newName: "Company_Id");
            CreateIndex("dbo.PetrolStations", "Company_Id");
            AddForeignKey("dbo.PetrolStations", "Company_Id", "dbo.Companies", "Id");
        }
    }
}
