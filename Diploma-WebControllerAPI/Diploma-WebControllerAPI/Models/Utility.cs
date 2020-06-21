using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diploma_WebControllerAPI.Models
{
    public partial class Utility
    {
        public Utility()
        {
            Region = new HashSet<Region>();
            RegionDailyStatistics = new HashSet<RegionDailyStatistics>();
            Trip = new HashSet<Trip>();
        }

        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public bool Ready { get; set; }
        public int LocationId { get; set; }
        public int UtilityOptionsId { get; set; }
        public int UtilityCompanyId { get; set; }

        public virtual Location Location { get; set; }
        public virtual UtilityOptions UtilityOptions { get; set; }
        public virtual UtilityCompany UtilityCompany { get; set; }
        public virtual ICollection<Region> Region { get; set; }
        public virtual ICollection<RegionDailyStatistics> RegionDailyStatistics { get; set; }
        public virtual ICollection<Trip> Trip { get; set; }
        public virtual ICollection<ContainerDistance> ContainerDistances { get; set; }
    }
}
