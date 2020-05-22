using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma_WebControllerAPI.Models;

namespace Diploma_WebControllerAPI.DataGenerator
{
    public class UtilityGenerator //розтавити точки компаній
    {
        public bool Generate()
        {
            using (var dimplomaDbContext = new DiplomaDBContext())
            {
                var utilityCompanies = new List<UtilityCompany>();
                var utilityOptions = new List<UtilityOptions>();
                var utilities = new List<Utility>();
                var locations = new List<Location>();
                var locationID = dimplomaDbContext.Location.Count();

                utilityCompanies.Add(new UtilityCompany { Id = 1, Name = "Smart Garbage" });
                utilityCompanies.Add(new UtilityCompany { Id = 2, Name = "ReCycler" });
                utilityCompanies.Add(new UtilityCompany { Id = 3, Name = "Екологічний збирач" });

                utilityOptions.Add(new UtilityOptions { Id = 1, MaxTripsDaily = 5, DynamicTrip = false });
                utilityOptions.Add(new UtilityOptions { Id = 2, MaxTripsDaily = 5, DynamicTrip = true });
                utilityOptions.Add(new UtilityOptions { Id = 3, MaxTripsDaily = 2, DynamicTrip = false });

                locations.Add(new Location { Id = locationID + 1, Latitude = 50.454626, Longitude = 30.392641 });
                utilities.Add(new Utility { Id = 1, Name= "Подільське", Ready = true, LocationId = locationID + 1, UtilityOptionsId = 2, UtilityCompanyId = 1});
                locations.Add(new Location { Id = locationID + 2, Latitude = 50.403216, Longitude = 30.408973 });
                utilities.Add(new Utility { Id = 2, Name = "Солом'янське", Ready = true, LocationId = locationID + 2, UtilityOptionsId = 1, UtilityCompanyId = 2 });
                locations.Add(new Location { Id = locationID + 3, Latitude = 50.516066, Longitude = 30.645244 });
                utilities.Add(new Utility { Id = 3, Name = "Деснянське", Ready = true, LocationId = locationID + 3, UtilityOptionsId = 3, UtilityCompanyId = 3 });

                locations.Add(new Location { Id = locationID + 4, Latitude = 49.778122, Longitude = 23.977127 });
                utilities.Add(new Utility { Id = 4, Name = "Франківське", Ready = true, LocationId = locationID + 4, UtilityOptionsId = 1, UtilityCompanyId = 1 });
                locations.Add(new Location { Id = locationID + 5, Latitude = 49.861935, Longitude = 24.000125 });
                utilities.Add(new Utility { Id = 5, Name = "Шевченківське", Ready = true, LocationId = locationID + 5, UtilityOptionsId = 2, UtilityCompanyId = 2 });

                locations.Add(new Location { Id = locationID + 6, Latitude = 50.010102, Longitude = 36.362880 });
                utilities.Add(new Utility { Id = 6, Name = "Московське", Ready = true, LocationId = locationID + 6, UtilityOptionsId = 1, UtilityCompanyId = 1 });

                locations.Add(new Location { Id = locationID + 7, Latitude = 46.162043, Longitude = 30.491838 });
                utilities.Add(new Utility { Id = 7, Name = "Київське", Ready = true, LocationId = locationID + 7, UtilityOptionsId = 2, UtilityCompanyId = 2 });

                if (dimplomaDbContext.Utility.Count() == utilities.Count)
                    return true;

                dimplomaDbContext.Location.AddRange(locations);
                dimplomaDbContext.UtilityCompany.AddRange(utilityCompanies);
                dimplomaDbContext.UtilityOptions.AddRange(utilityOptions);
                dimplomaDbContext.Utility.AddRange(utilities);
                var result = dimplomaDbContext.SaveChanges();
                return result > 0;
            }

        }
    }
}
