using System;
using System.Collections.Generic;

namespace Diploma_WebControllerAPI.Models
{
    public partial class Utility
    {
        public Utility()
        {
            CityUtilities = new HashSet<CityUtilities>();
            Region = new HashSet<Region>();
            RegionDailyStatistics = new HashSet<RegionDailyStatistics>();
            Trip = new HashSet<Trip>();
        }

        public int Id { get; set; }
        public bool Ready { get; set; }
        public int LocationId { get; set; }
        public int UtilityOptionsId { get; set; }

        public virtual Location Location { get; set; }
        public virtual UtilityOptions UtilityOptions { get; set; }
        public virtual ICollection<CityUtilities> CityUtilities { get; set; }
        public virtual ICollection<Region> Region { get; set; }
        public virtual ICollection<RegionDailyStatistics> RegionDailyStatistics { get; set; }
        public virtual ICollection<Trip> Trip { get; set; }
    }
}
