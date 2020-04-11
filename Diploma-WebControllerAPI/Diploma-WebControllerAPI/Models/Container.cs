using System;
using System.Collections.Generic;

namespace Diploma_WebControllerAPI.Models
{
    public partial class Container
    {
        public Container()
        {
            TripContainers = new HashSet<TripContainers>();
        }

        public int Id { get; set; }
        public bool Full { get; set; }
        public DateTime? LastGather { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int RegionId { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<TripContainers> TripContainers { get; set; }
    }
}
