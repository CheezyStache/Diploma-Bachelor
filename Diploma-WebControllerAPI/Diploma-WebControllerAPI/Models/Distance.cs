using System;
using System.Collections.Generic;

namespace Diploma_WebControllerAPI.Models
{
    public partial class Distance
    {
        public Distance()
        {
            ContainerDistances = new HashSet<ContainerDistance>();
        }

        public int Id { get; set; }
        public double Value { get; set; }

        public virtual ICollection<ContainerDistance> ContainerDistances { get; set; }
    }
}
