using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diploma_WebControllerAPI.Models;
using Diploma_WebControllerAPI.ViewModels;

namespace Diploma_WebControllerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private DiplomaDBContext diplomaDBContext;

        private readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            IgnoreNullValues = true
        };

        [HttpGet("country")]
        public string CountryDashboard()
        {
            var result = "";

            using (diplomaDBContext = new DiplomaDBContext())
            {
                var dailyTripList = diplomaDBContext.Trip.Where(t => t.Date.Date == DateTime.Today && !t.InProgress).ToList();

                var dailyStatistics = new CountryDailyStatistics
                {
                    Date = DateTime.Today,
                    CitiesCount = diplomaDBContext.City.Count(),
                    AvgTime = (long?)dailyTripList.Average(t => t.Time),
                    AvgPetrolAmount = (int?)dailyTripList.Average(t => t.PetrolAmount.Value),
                    PetrolAmount = dailyTripList.Sum(t => t.PetrolAmount).HasValue ? dailyTripList.Sum(t => t.PetrolAmount).Value : 0,
                    AvgDynamicChangesCount = (int?)dailyTripList.Average(t => t.DynamicChangesCount.Value),
                    DynamicChangesCount = dailyTripList.Sum(t => t.DynamicChangesCount).HasValue ? dailyTripList.Sum(t => t.DynamicChangesCount).Value : 0,
                    AvgContainersCount = (int?)dailyTripList.Average(t => t.TripContainers.Count()),
                    CollectedContainersCount = dailyTripList.Sum(t => t.TripContainers.Count()),
                    ContainersCount = diplomaDBContext.Container.Count(),
                    UtilitiesCount = diplomaDBContext.Utility.Count(),
                    RegionsCount = diplomaDBContext.Region.Count(),
                    FactoriesCount = diplomaDBContext.RecycleFactory.Count()
                };

                result = JsonSerializer.Serialize(dailyStatistics, JsonOptions);
            }

            return result;
        }

        [HttpGet("city/{id}")]
        public string CityDashboard(int id)
        {
            var result = "";

            using (diplomaDBContext = new DiplomaDBContext())
            {
                var dailyTripList = diplomaDBContext.Trip.Where(t => t.Date.Date == DateTime.Today && !t.InProgress && t.TripContainers.Any() && t.TripContainers.First().Container.Region.City.Id == id).ToList();

                var dailyStatistics = new DailyStatistics
                {
                    Date = DateTime.Today,
                    CityId = id,
                    AvgTime = (long?)dailyTripList.Average(t => t.Time),
                    AvgPetrolAmount = (int?)dailyTripList.Average(t => t.PetrolAmount.Value),
                    PetrolAmount = dailyTripList.Sum(t => t.PetrolAmount).HasValue ? dailyTripList.Sum(t => t.PetrolAmount).Value : 0,
                    AvgDynamicChangesCount = (int?)dailyTripList.Average(t => t.DynamicChangesCount.Value),
                    DynamicChangesCount = dailyTripList.Sum(t => t.DynamicChangesCount).HasValue ? dailyTripList.Sum(t => t.DynamicChangesCount).Value : 0,
                    AvgContainersCount = (int?)dailyTripList.Average(t => t.TripContainers.Count()),
                    CollectedContainersCount = dailyTripList.Sum(t => t.TripContainers.Count()),
                    ContainersCount = diplomaDBContext.Container.Count(),
                    UtilitiesCount = diplomaDBContext.Utility.Count(),
                    RegionsCount = diplomaDBContext.Region.Count(),
                    FactoriesCount = diplomaDBContext.RecycleFactory.Count()
                };

                result = JsonSerializer.Serialize(dailyStatistics, JsonOptions);
            }

            return result;
        }

        [HttpGet("region/{id}")]
        public string RegionDashboard(int id)
        {
            var result = "";

            using (diplomaDBContext = new DiplomaDBContext())
            {
                var dailyTripList = diplomaDBContext.Trip.Where(t => t.Date.Date == DateTime.Today && !t.InProgress && t.TripContainers.Any() && t.TripContainers.First().Container.Region.Id == id).ToList();

                var dailyStatistics = new RegionDailyStatistics
                {
                    Date = DateTime.Today,
                    AvgTime = (long?)dailyTripList.Average(t => t.Time),
                    AvgPetrolAmount = (int?)dailyTripList.Average(t => t.PetrolAmount.Value),
                    PetrolAmount = dailyTripList.Sum(t => t.PetrolAmount).HasValue ? dailyTripList.Sum(t => t.PetrolAmount).Value : 0,
                    AvgDynamicChangesCount = (int?)dailyTripList.Average(t => t.DynamicChangesCount.Value),
                    DynamicChangesCount = dailyTripList.Sum(t => t.DynamicChangesCount).HasValue ? dailyTripList.Sum(t => t.DynamicChangesCount).Value : 0,
                    AvgContainersCount = (int?)dailyTripList.Average(t => t.TripContainers.Count()),
                    CollectedContainersCount = dailyTripList.Sum(t => t.TripContainers.Count()),
                    ContainersCount = diplomaDBContext.Container.Count(),
                    UtilityId = dailyTripList.First().UtilityId,
                    RegionId = dailyTripList.First().TripContainers.First().Container.RegionId
                };

                result = JsonSerializer.Serialize(dailyStatistics, JsonOptions);
            }

            return result;
        }

        [HttpGet("cities")]
        public string Cities()
        {
            var result = "";

            using (diplomaDBContext = new DiplomaDBContext())
            {
                var cities = diplomaDBContext.City.Select(c => new CityViewModel(c)).ToList();

                result = JsonSerializer.Serialize(cities, JsonOptions);
            }

            return result;
        }

        [HttpGet("regions/{id}")]
        public string Regions(int id)
        {
            var result = "";

            using (diplomaDBContext = new DiplomaDBContext())
            {
                var regions = diplomaDBContext.Region.Where(r => r.CityId == id).Select(r => new RegionViewModel(r)).ToList();

                result = JsonSerializer.Serialize(regions, JsonOptions);
            }

            return result;
        }
    }
}