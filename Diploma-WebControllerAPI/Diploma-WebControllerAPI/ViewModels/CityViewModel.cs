using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma_WebControllerAPI.Models;

namespace Diploma_WebControllerAPI.ViewModels
{
    public class CityViewModel
    {
        public string Name { get; set; }
        public long Population { get; set; }
        public int RegionsCount { get; set; }
        public int ContainersCount { get; set; }

        public CityViewModel(City city)
        {
            Name = city.Name;
            Population = city.Population;
            RegionsCount = city.Region.Count();
            ContainersCount = city.Region.Sum(r => r.Container.Count());
        }
    }
}
