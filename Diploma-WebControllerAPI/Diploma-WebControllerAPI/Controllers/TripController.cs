using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diploma_WebControllerAPI.Models;
using Diploma_WebControllerAPI.TSP;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace Diploma_WebControllerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            IgnoreNullValues = true
        };

        private DiplomaDBContext diplomaDBContext;

        [HttpGet("trip/{regionId}")]
        public string BuildTripByRegion(int regionId)
        {
            using (diplomaDBContext = new DiplomaDBContext())
            {
                //var containers = diplomaDBContext.Container.Where(c => c.RegionId == regionId).Where(c => c.Full).ToArray();
                var containers = diplomaDBContext.Container.Where(c => c.RegionId == regionId && c.Ready).Include(c => c.Location).ToArray();
                var utility = diplomaDBContext.Utility.Include(u => u.Location).First(u => u.Region.Select(r => r.Id).Contains(regionId));
                var recycleFactory = diplomaDBContext.RecycleFactory.Include(f => f.Location).First(f => f.Region.Select(r => r.Id).Contains(regionId));

                GA_TSP tsp = new GA_TSP(containers, utility, recycleFactory);
                tsp.Initialization();
                var indexes = tsp.TSPCompute();
                System.Diagnostics.Debug.WriteLine("Prod" + tsp.ArrayDistance(indexes));

                var zeroIndex = Array.IndexOf(indexes, 0);
                var endIndex = Array.IndexOf(indexes, indexes.Length - 1);
                var startIndex = zeroIndex < endIndex ? zeroIndex : endIndex;

                int[] indexPath;
                if (zeroIndex == 0)
                    indexPath = indexes.Skip(1).Take(indexes.Length - 2).ToArray();
                else
                    indexPath = indexes.Take(startIndex).Concat(indexes.Skip(startIndex + 2)).ToArray();

                var tripContainers = indexPath.Select(i => containers[i - 1]).ToList();

                var containerLocations = tripContainers.Select(c => c.Location).ToArray();

                var containerPath = new List<Diploma_WebControllerAPI.ViewModels.Location>();
                containerPath.Add(new Diploma_WebControllerAPI.ViewModels.Location { Latitude = utility.Location.Latitude, Longitude = utility.Location.Longitude });

                for (int i = 0; i < containerLocations.Length; i++)
                {
                    containerPath.Add(new Diploma_WebControllerAPI.ViewModels.Location { Latitude = containerLocations[i].Latitude, Longitude = containerLocations[i].Longitude });
                }

                containerPath.Add(new Diploma_WebControllerAPI.ViewModels.Location { Latitude = recycleFactory.Location.Latitude, Longitude = recycleFactory.Location.Longitude });

                var result = JsonSerializer.Serialize(containerPath, JsonOptions);

                Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
                return result;
            }
        }

        [HttpGet("testTrip/{regionId}")]
        public string BuildTestTripByRegion(int regionId)
        {
            using (diplomaDBContext = new DiplomaDBContext())
            {
                //var containers = diplomaDBContext.Container.Where(c => c.RegionId == regionId).Where(c => c.Full).ToArray();
                var containers = diplomaDBContext.Container.Where(c => c.RegionId == regionId && c.Ready).Include(c => c.Location).ToArray();
                var utility = diplomaDBContext.Utility.Include(u => u.Location).First(u => u.Region.Select(r => r.Id).Contains(regionId));
                var recycleFactory = diplomaDBContext.RecycleFactory.Include(f => f.Location).First(f => f.Region.Select(r => r.Id).Contains(regionId));

                GA_TSP tsp = new GA_TSP(containers, utility, recycleFactory);
                var indexes = tsp.TestFlow();
                System.Diagnostics.Debug.WriteLine("Test" + tsp.ArrayDistance(indexes));

                var zeroIndex = Array.IndexOf(indexes, 0);
                var endIndex = Array.IndexOf(indexes, indexes.Length - 1);
                var startIndex = zeroIndex < endIndex ? zeroIndex : endIndex;

                int[] indexPath;
                if (zeroIndex == 0)
                    indexPath = indexes.Skip(1).Take(indexes.Length - 2).ToArray();
                else
                    indexPath = indexes.Take(startIndex).Concat(indexes.Skip(startIndex + 2)).ToArray();

                var tripContainers = indexPath.Select(i => containers[i - 1]).ToList();

                var containerLocations = tripContainers.Select(c => c.Location).ToArray();

                var containerPath = new List<Diploma_WebControllerAPI.ViewModels.Location>();
                containerPath.Add(new Diploma_WebControllerAPI.ViewModels.Location { Latitude = utility.Location.Latitude, Longitude = utility.Location.Longitude });

                for (int i = 0; i < containerLocations.Length; i++)
                {
                    containerPath.Add(new Diploma_WebControllerAPI.ViewModels.Location { Latitude = containerLocations[i].Latitude, Longitude = containerLocations[i].Longitude });
                }

                containerPath.Add(new Diploma_WebControllerAPI.ViewModels.Location { Latitude = recycleFactory.Location.Latitude, Longitude = recycleFactory.Location.Longitude });

                var result = JsonSerializer.Serialize(containerPath, JsonOptions);

                Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
                return result;
            }
        }
    }
}