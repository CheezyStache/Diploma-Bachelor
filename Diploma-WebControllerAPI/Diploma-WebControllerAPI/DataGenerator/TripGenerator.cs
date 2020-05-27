using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma_WebControllerAPI.Models;

namespace Diploma_WebControllerAPI.DataGenerator
{
    public class TripGenerator
    {
        public bool Generate()
        {
            var trips = new List<Trip>();
            var tripContainers = new List<TripContainers>();

            trips.Add(new Trip { Id = 1, Time = TimeSpan.FromMinutes(43).Ticks‬, Date = DateTime.Parse("5/4/2020 12:15:12 PM"), PetrolAmount = 14, InProgress = false, UtilityId = 1 });
            tripContainers.Add(new TripContainers { Id = 1, TripId = 1, ContainerId = 1 });
            tripContainers.Add(new TripContainers { Id = 2, TripId = 1, ContainerId = 2 });
            tripContainers.Add(new TripContainers { Id = 3, TripId = 1, ContainerId = 3 });

            trips.Add(new Trip { Id = 2, Time = TimeSpan.FromMinutes(42).Ticks‬, Date = DateTime.Parse("6/4/2020 12:48:12 PM"), PetrolAmount = 10, InProgress = false, UtilityId = 1 });
            tripContainers.Add(new TripContainers { Id = 4, TripId = 2, ContainerId = 1 });
            tripContainers.Add(new TripContainers { Id = 5, TripId = 2, ContainerId = 2 });
            tripContainers.Add(new TripContainers { Id = 6, TripId = 2, ContainerId = 3 });
            tripContainers.Add(new TripContainers { Id = 7, TripId = 2, ContainerId = 4 });

            trips.Add(new Trip { Id = 3, Time = TimeSpan.FromMinutes(50).Ticks‬, Date = DateTime.Parse("6/4/2020 12:59:12 PM"), PetrolAmount = 21, InProgress = false, UtilityId = 1 });
            tripContainers.Add(new TripContainers { Id = 8, TripId = 3, ContainerId = 2 });
            tripContainers.Add(new TripContainers { Id = 9, TripId = 3, ContainerId = 3 });
            tripContainers.Add(new TripContainers { Id = 10, TripId = 3, ContainerId = 4 });

            trips.Add(new Trip { Id = 4, Date = DateTime.Parse("7/4/2020 13:14:12 PM"), InProgress = true, UtilityId = 1 });
            tripContainers.Add(new TripContainers { Id = 11, TripId = 4, ContainerId = 1 });
            tripContainers.Add(new TripContainers { Id = 12, TripId = 4, ContainerId = 2 });
            tripContainers.Add(new TripContainers { Id = 13, TripId = 4, ContainerId = 3 });
            tripContainers.Add(new TripContainers { Id = 14, TripId = 4, ContainerId = 4 });

            trips.Add(new Trip { Id = 5, Time = TimeSpan.FromMinutes(56).Ticks‬, Date = DateTime.Parse("7/4/2020 11:26:12 PM"), PetrolAmount = 10, InProgress = false, UtilityId = 2 });
            tripContainers.Add(new TripContainers { Id = 15, TripId = 5, ContainerId = 5 });
            tripContainers.Add(new TripContainers { Id = 16, TripId = 5, ContainerId = 6 });
            tripContainers.Add(new TripContainers { Id = 17, TripId = 5, ContainerId = 7 });

            trips.Add(new Trip { Id = 6, Time = TimeSpan.FromMinutes(41).Ticks‬, Date = DateTime.Parse("8/4/2020 17:54:12 PM"), PetrolAmount = 23, InProgress = false, UtilityId = 2 });
            tripContainers.Add(new TripContainers { Id = 18, TripId = 6, ContainerId = 5 });
            tripContainers.Add(new TripContainers { Id = 19, TripId = 6, ContainerId = 7 });

            trips.Add(new Trip { Id = 7, Time = TimeSpan.FromMinutes(49).Ticks‬, Date = DateTime.Parse("9/4/2020 15:15:12 PM"), PetrolAmount = 14, InProgress = false, UtilityId = 3 });
            tripContainers.Add(new TripContainers { Id = 20, TripId = 7, ContainerId = 8 });
            tripContainers.Add(new TripContainers { Id = 21, TripId = 7, ContainerId = 9 });

            trips.Add(new Trip { Id = 8, Time = TimeSpan.FromMinutes(74).Ticks‬, Date = DateTime.Parse("10/4/2020 19:15:12 PM"), PetrolAmount = 15, InProgress = false, UtilityId = 3 });
            tripContainers.Add(new TripContainers { Id = 22, TripId = 8, ContainerId = 8 });

            trips.Add(new Trip { Id = 9, Time = TimeSpan.FromMinutes(36).Ticks‬, Date = DateTime.Parse("10/4/2020 13:05:12 PM"), PetrolAmount = 10, InProgress = false, UtilityId = 4 });
            tripContainers.Add(new TripContainers { Id = 23, TripId = 9, ContainerId = 10 });
            tripContainers.Add(new TripContainers { Id = 24, TripId = 9, ContainerId = 11 });
            tripContainers.Add(new TripContainers { Id = 25, TripId = 9, ContainerId = 12 });

            trips.Add(new Trip { Id = 10, Time = TimeSpan.FromMinutes(65).Ticks‬, Date = DateTime.Parse("11/4/2020 18:45:12 PM"), PetrolAmount = 19, InProgress = false, UtilityId = 4 });
            tripContainers.Add(new TripContainers { Id = 26, TripId = 10, ContainerId = 10 });

            trips.Add(new Trip { Id = 11, Time = TimeSpan.FromMinutes(46).Ticks‬, Date = DateTime.Parse("12/4/2020 08:34:12 PM"), PetrolAmount = 9, InProgress = false, UtilityId = 4 });
            tripContainers.Add(new TripContainers { Id = 27, TripId = 11, ContainerId = 10 });
            tripContainers.Add(new TripContainers { Id = 28, TripId = 11, ContainerId = 11 });
            tripContainers.Add(new TripContainers { Id = 29, TripId = 11, ContainerId = 12 });

            trips.Add(new Trip { Id = 12, Time = TimeSpan.FromMinutes(49).Ticks‬, Date = DateTime.Parse("12/4/2020 16:15:12 PM"), PetrolAmount = 11, InProgress = false, UtilityId = 5 });
            tripContainers.Add(new TripContainers { Id = 30, TripId = 12, ContainerId = 13 });
            tripContainers.Add(new TripContainers { Id = 31, TripId = 12, ContainerId = 14 });

            trips.Add(new Trip { Id = 13, Date = DateTime.Parse("15/4/2020 17:23:12 PM"), InProgress = true, UtilityId = 5 });
            tripContainers.Add(new TripContainers { Id = 32, TripId = 13, ContainerId = 14 });

            trips.Add(new Trip { Id = 14, Time = TimeSpan.FromMinutes(79).Ticks‬, Date = DateTime.Parse("16/4/2020 12:18:12 PM"), PetrolAmount = 15, InProgress = false, UtilityId = 6 });
            tripContainers.Add(new TripContainers { Id = 33, TripId = 14, ContainerId = 15 });

            trips.Add(new Trip { Id = 15, Time = TimeSpan.FromMinutes(58).Ticks‬, Date = DateTime.Parse("17/4/2020 12:46:12 PM"), PetrolAmount = 12, InProgress = false, UtilityId = 6 });
            tripContainers.Add(new TripContainers { Id = 34, TripId = 15, ContainerId = 15 });
            tripContainers.Add(new TripContainers { Id = 35, TripId = 15, ContainerId = 16 });

            trips.Add(new Trip { Id = 16, Time = TimeSpan.FromMinutes(72).Ticks‬, Date = DateTime.Parse("18/4/2020 11:26:12 PM"), PetrolAmount = 11, InProgress = false, UtilityId = 7 });
            tripContainers.Add(new TripContainers { Id = 36, TripId = 16, ContainerId = 17 });
            tripContainers.Add(new TripContainers { Id = 37, TripId = 16, ContainerId = 18 });

            using (var dimplomaDbContext = new DiplomaDBContext())
            {
                if (dimplomaDbContext.Trip.Count() == trips.Count)
                    return true;

                dimplomaDbContext.Trip.AddRange(trips);
                dimplomaDbContext.TripContainers.AddRange(tripContainers);
                var result = dimplomaDbContext.SaveChanges();
                return result > 0;
            }

        }
    }
}
