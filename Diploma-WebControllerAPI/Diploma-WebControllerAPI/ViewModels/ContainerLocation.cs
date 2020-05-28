using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma_WebControllerAPI.ViewModels
{
    public class ContainerLocation
    {
        public int Id { get; set; }
        public bool Full { get; set; }
        public bool Ready { get; set; }
        public DateTime? LastGather { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string Region { get; set; }
        public Location Location { get; set; }
    }
}
