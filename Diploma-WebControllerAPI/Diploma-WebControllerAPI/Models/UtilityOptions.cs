using System;
using System.Collections.Generic;

namespace Diploma_WebControllerAPI.Models
{
    public partial class UtilityOptions
    {
        public UtilityOptions()
        {
            Utility = new HashSet<Utility>();
        }

        public int Id { get; set; }
        public int MaxTripsDaily { get; set; }
        public bool DynamicTrip { get; set; }

        public virtual ICollection<Utility> Utility { get; set; }
    }
}
