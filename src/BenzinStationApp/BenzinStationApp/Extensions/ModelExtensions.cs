using System;
using BenzinStationApp.Models;

namespace BenzinStationApp.Extensions
{
    public static class ModelExtensions
    {
        public static void TransferTo<TPetrolPrice>(this IPetrolPrice source, TPetrolPrice destination) where TPetrolPrice : IPetrolPrice,new()
        {
            if (destination == null)
                throw new ArgumentNullException("destination");

            destination.Diesel = source.Diesel;
            destination.Unleaded92 = source.Unleaded92;
            destination.Unleader95 = source.Unleader95;
            destination.StartTime = source.StartTime;
        }
    }
}