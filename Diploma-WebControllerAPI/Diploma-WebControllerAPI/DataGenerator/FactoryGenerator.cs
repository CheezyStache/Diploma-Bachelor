using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma_WebControllerAPI.Models;

namespace Diploma_WebControllerAPI.DataGenerator
{
    public class FactoryGenerator
    {
        public bool Generate()
        {
            using (var dimplomaDbContext = new DiplomaDBContext())
            {
                var factories = new List<RecycleFactory>();
                var locations = new List<Location>();
                var locationID = dimplomaDbContext.Location.Count();

                locations.Add(new Location { Id = locationID + 1, Latitude = 50.505233, Longitude = 30.369190 });
                factories.Add(new RecycleFactory { Id = 1, Name = "Подільська", Ready = true, LocationId = locationID + 1 });
                locations.Add(new Location { Id = locationID + 2, Latitude = 50.388018, Longitude = 30.424760 });
                factories.Add(new RecycleFactory { Id = 2, Name = "Солом'янська", Ready = false, LocationId = locationID + 2 });
                locations.Add(new Location { Id = locationID + 3, Latitude = 50.499461, Longitude = 30.623677 });
                factories.Add(new RecycleFactory { Id = 3, Name = "Деснянська", Ready = true, LocationId = locationID + 3 });

                locations.Add(new Location { Id = locationID + 4, Latitude = 49.793591, Longitude = 23.999443 });
                factories.Add(new RecycleFactory { Id = 4, Name = "Франківська", Ready = true, LocationId = locationID + 4 });
                locations.Add(new Location { Id = locationID + 5, Latitude = 49.879258, Longitude = 23.935561 });
                factories.Add(new RecycleFactory { Id = 5, Name = "Шевченківська", Ready = false, LocationId = locationID + 5 });

                locations.Add(new Location { Id = locationID + 6, Latitude = 50.008183, Longitude = 36.365031 });
                factories.Add(new RecycleFactory { Id = 6, Name = "Московська", Ready = true, LocationId = locationID + 6 });

                locations.Add(new Location { Id = locationID + 7, Latitude = 46.306806, Longitude = 30.667112 });
                factories.Add(new RecycleFactory { Id = 7, Name = "Київська", Ready = false, LocationId = locationID + 7 });

                if (dimplomaDbContext.RecycleFactory.Count() == factories.Count)
                    return true;

                dimplomaDbContext.Location.AddRange(locations);
                dimplomaDbContext.RecycleFactory.AddRange(factories);
                var result = dimplomaDbContext.SaveChanges();
                return result > 0;
            }

        }
    }
}
