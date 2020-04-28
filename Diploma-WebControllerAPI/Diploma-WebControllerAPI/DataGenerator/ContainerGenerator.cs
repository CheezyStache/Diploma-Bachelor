using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma_WebControllerAPI.Models;

namespace Diploma_WebControllerAPI.DataGenerator
{
    public class ContainerGenerator
    {
        public bool Generate()
        {
            using (var dimplomaDbContext = new DiplomaDBContext())
            {
                var containers = new List<Container>();
                var locations = new List<Location>();
                var locationID = dimplomaDbContext.Location.Count();

                locations.Add(new Location { Id = locationID + 1, Latitude = 50.481311, Longitude = 30.447621 });
                containers.Add(new Container { Id = 1, Full = true, LastGather = DateTime.Today, LastUpdate = DateTime.Now, RegionId = 1, LocationId = locationID + 1 });
                locations.Add(new Location { Id = locationID + 2, Latitude = 50.487537, Longitude = 30.461869 });
                containers.Add(new Container { Id = 2, Full = false, RegionId = 1, LocationId = locationID + 2 });
                locations.Add(new Location { Id = locationID + 3, Latitude = 50.498020, Longitude = 30.430885 });
                containers.Add(new Container { Id = 3, Full = false, RegionId = 1, LocationId = locationID + 3 });
                locations.Add(new Location { Id = locationID + 4, Latitude = 50.484407, Longitude = 30.409400 });
                containers.Add(new Container { Id = 4, Full = false, RegionId = 1, LocationId = locationID + 4 });

                locations.Add(new Location { Id = locationID + 5, Latitude = 50.426658, Longitude = 30.431529 });
                containers.Add(new Container { Id = 5, Full = true, LastGather = DateTime.Today, LastUpdate = DateTime.Now, RegionId = 2, LocationId = locationID + 5 });
                locations.Add(new Location { Id = locationID + 6, Latitude = 50.449411, Longitude = 30.451433 });
                containers.Add(new Container { Id = 6, Full = false, RegionId = 2, LocationId = locationID + 6 });
                locations.Add(new Location { Id = locationID + 7, Latitude = 50.435261, Longitude = 30.404290 });
                containers.Add(new Container { Id = 7, Full = false, RegionId = 2, LocationId = locationID + 7 });

                locations.Add(new Location { Id = locationID + 8, Latitude = 50.526426, Longitude = 30.607576 });
                containers.Add(new Container { Id = 8, Full = false, RegionId = 3, LocationId = locationID + 8 });
                locations.Add(new Location { Id = locationID + 9, Latitude = 50.515621, Longitude = 30.618905 });
                containers.Add(new Container { Id = 9, Full = false, RegionId = 3, LocationId = locationID + 9 });

                locations.Add(new Location { Id = locationID + 10, Latitude = 49.803150, Longitude = 24.006202 });
                containers.Add(new Container { Id = 10, Full = true, LastGather = DateTime.Today, LastUpdate = DateTime.Now, RegionId = 4, LocationId = locationID + 10 });
                locations.Add(new Location { Id = locationID + 11, Latitude = 49.820143, Longitude = 23.996199 });
                containers.Add(new Container { Id = 11, Full = false, RegionId = 4, LocationId = locationID + 11 });
                locations.Add(new Location { Id = locationID + 12, Latitude = 49.782196, Longitude = 23.993954 });
                containers.Add(new Container { Id = 12, Full = false, RegionId = 4, LocationId = locationID + 12 });

                locations.Add(new Location { Id = locationID + 13, Latitude = 49.858966, Longitude = 24.010917 });
                containers.Add(new Container { Id = 13, Full = false, RegionId = 5, LocationId = locationID + 13 });
                locations.Add(new Location { Id = locationID + 14, Latitude = 49.857675, Longitude = 24.036650 });
                containers.Add(new Container { Id = 14, Full = false, RegionId = 5, LocationId = locationID + 14 });

                locations.Add(new Location { Id = locationID + 15, Latitude = 49.982480, Longitude = 36.327721 });
                containers.Add(new Container { Id = 15, Full = true, LastGather = DateTime.Today, LastUpdate = DateTime.Now, RegionId = 6, LocationId = locationID + 15 });
                locations.Add(new Location { Id = locationID + 16, Latitude = 49.997620, Longitude = 36.325779 });
                containers.Add(new Container { Id = 16, Full = false, RegionId = 6, LocationId = locationID + 16 });

                locations.Add(new Location { Id = locationID + 17, Latitude = 46.375962, Longitude = 30.703967 });
                containers.Add(new Container { Id = 17, Full = false, RegionId = 7, LocationId = locationID + 17 });
                locations.Add(new Location { Id = locationID + 18, Latitude = 46.420496, Longitude = 30.744509 });
                containers.Add(new Container { Id = 18, Full = false, RegionId = 7, LocationId = locationID + 18 });

                if (dimplomaDbContext.Container.Count() == containers.Count)
                    return true;

                dimplomaDbContext.Location.AddRange(locations);
                dimplomaDbContext.Container.AddRange(containers);
                var result = dimplomaDbContext.SaveChanges();
                return result > 0;
            }

        }
    }
}
