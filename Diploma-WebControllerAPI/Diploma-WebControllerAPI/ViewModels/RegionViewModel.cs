using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma_WebControllerAPI.Models;

namespace Diploma_WebControllerAPI.ViewModels
{
    public class RegionViewModel
    {
        public string Name { get; set; }
        public long Population { get; set; }
        public int ContainersCount { get; set; }
        public string Utility { get; set; }
        public string Factory { get; set; }

        public RegionViewModel(Region region)
        {
            Name = region.Name;
            Population = region.Population;
            ContainersCount = region.Container.Count();
            Utility = region.Utility.Name;
            Factory = region.RecycleFactory.Name;
        }
    }
}
