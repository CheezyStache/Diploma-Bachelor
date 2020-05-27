using System;
using System.Collections.Generic;

namespace Diploma_WebControllerAPI.Models
{
    public partial class TripContainers
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public int ContainerId { get; set; }

        public virtual Container Container { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
