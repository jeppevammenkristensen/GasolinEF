using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Spatial;

namespace BenzinStationApp.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string HomePage { get; set; }

        public virtual List<PetrolStation> Stations { get; set; }

    }

    public class PetrolStation
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public DbGeography Location { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public virtual List<PetrolPrice> Prices { get; set; }
    }

    public class PetrolPrice : IPetrolPrice
    {
        public Guid Id { get; set; }
        public decimal Unleaded92 { get; set; }
        public decimal Unleader95 { get; set; }
        public decimal Diesel { get; set; }
        public DateTime StartTime { get; set; }

        
    }

    public interface IPetrolPrice
    {
        decimal Unleaded92 { get; set; }
        decimal Unleader95 { get; set; }
        decimal Diesel { get; set; }
        DateTime StartTime { get; set; }
    }

    public class GasolinContext : DbContext
    {
        public DbSet<PetrolStation> PetrolStations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<PetrolPrice> PetrolPrices { get; set; }
    }
}