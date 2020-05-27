using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma_WebControllerAPI.ViewModels
{
    public class UtilityLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Ready { get; set; }
        public string[] Regions { get; set; }
        public Location Location { get; set; }
    }
}
