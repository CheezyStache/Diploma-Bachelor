using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma_WebControllerAPI.ViewModels
{
    public class FactoryLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Ready { get; set; }
        public string Region { get; set; }
        public Location Location { get; set; }
    }
}
