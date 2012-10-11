using System;
using System.ComponentModel.DataAnnotations;
using BenzinStationApp.Models;

namespace BenzinStationApp.Commands
{
    public class AddPetrolPriceCommand : IPetrolPrice
    {
        [Required]
        public int PetrolStationId { get; set; }
        
        [Required]
        public decimal Unleaded92 { get; set; }
        
        [Required]
        public decimal Unleader95 { get; set; }
        
        [Required]
        public decimal Diesel { get; set; }

        public DateTime StartTime { get; set; }
    }
}