using System;
using System.Collections.Generic;

namespace Diploma_WebControllerAPI.Models
{
    public partial class ContainerDistance
    {
        public int Id { get; set; }
        public int DistanceId { get; set; }
        public int? ContainerId { get; set; }
        public int? UtilityId { get; set; }
        public int? RecycleFactoryId { get; set; }

        public virtual Container Container { get; set; }
        public virtual Utility Utility { get; set; }
        public virtual RecycleFactory RecycleFactory { get; set; }
        public virtual Distance Distance { get; set; }
    }
}
