using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma_WebControllerAPI.Models;

namespace Diploma_WebControllerAPI.DataGenerator
{
    public class RegionGenerator
    {
        public bool Generate()
        {

            var regions = new List<Region>();

            regions.Add(new Region { Id = 1, Name = "Подільський", Population = 200617, Map = "", UtilityId = 1, RecycleFactoryId = 1, CityId = 1 });
            regions.Add(new Region { Id = 2, Name = "Солом'янський", Population = 373641, Map = "", UtilityId = 2, RecycleFactoryId = 2, CityId = 1 });
            regions.Add(new Region { Id = 3, Name = "Деснянський", Population = 368400, Map = "", UtilityId = 3, RecycleFactoryId = 3, CityId = 1 });
            regions.Add(new Region { Id = 4, Name = "Франківський", Population = 151100, Map = "", UtilityId = 4, RecycleFactoryId = 4, CityId = 2 });
            regions.Add(new Region { Id = 5, Name = "Шевченківський", Population = 143562, Map = "", UtilityId = 5, RecycleFactoryId = 5, CityId = 2 });
            regions.Add(new Region { Id = 6, Name = "Московський", Population = 304800, Map = "", UtilityId = 6, RecycleFactoryId = 6, CityId = 3 });
            regions.Add(new Region { Id = 7, Name = "Київський", Population = 256580, Map = "", UtilityId = 7, RecycleFactoryId = 7, CityId = 4 });

            using (var dimplomaDbContext = new DiplomaDBContext())
            {
                if (dimplomaDbContext.Region.Count() == regions.Count)
                    return true;

                dimplomaDbContext.Region.AddRange(regions);
                var result = dimplomaDbContext.SaveChanges();
                return result > 0;
            }

        }
    }
}
