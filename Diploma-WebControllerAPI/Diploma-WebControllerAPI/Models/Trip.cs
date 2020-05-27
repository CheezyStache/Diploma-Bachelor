using System;
using System.Collections.Generic;

namespace Diploma_WebControllerAPI.Models
{
    public partial class Trip
    {
        public Trip()
        {
            TripContainers = new HashSet<TripContainers>();
        }

        public int Id { get; set; }
        public long? Time { get; set; }
        public int? PetrolAmount { get; set; }
        public int? DynamicChangesCount { get; set; }
        public DateTime Date { get; set; }
        public bool InProgress { get; set; }
        public int UtilityId { get; set; }

        public virtual Utility Utility { get; set; }
        public virtual ICollection<TripContainers> TripContainers { get; set; }
    }
}
