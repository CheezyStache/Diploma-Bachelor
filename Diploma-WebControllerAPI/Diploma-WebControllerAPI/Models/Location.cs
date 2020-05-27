using System;
using System.Collections.Generic;

namespace Diploma_WebControllerAPI.Models
{
    public partial class Location
    {
        public Location()
        {
            Container = new HashSet<Container>();
            RecycleFactory = new HashSet<RecycleFactory>();
            Utility = new HashSet<Utility>();
        }

        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public virtual ICollection<Container> Container { get; set; }
        public virtual ICollection<RecycleFactory> RecycleFactory { get; set; }
        public virtual ICollection<Utility> Utility { get; set; }
    }
}
