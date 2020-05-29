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
            using(diplomaDBContext = new DiplomaDBContext())
            {
                //var containers = diplomaDBContext.Container.Where(c => c.RegionId == regionId).Where(c => c.Full).ToArray();
                var containers = diplomaDBContext.Container.Where(c => c.RegionId == regionId && c.Ready).Include(c => c.Location).ToArray();

                GA_TSP tsp = new GA_TSP(containers);
                tsp.Initialization();
                var indexes = tsp.TSPCompute();

                var tripContainers = new List<Container>();

                for(int i = 0; i < indexes.Length; i++)
                {
                    tripContainers.Add(containers[indexes[i]]);
                }

                var containerLocations = tripContainers.Select(c => c.Location).ToArray();

                var containerPath = new List<Diploma_WebControllerAPI.ViewModels.Location>();
                for(int i = 0; i < containerLocations.Length; i++)
                {
                    containerPath.Add(new Diploma_WebControllerAPI.ViewModels.Location {Latitude = containerLocations[i].Latitude, Longitude = containerLocations[i].Longitude});
                }

                var result = JsonSerializer.Serialize(containerPath, JsonOptions);

                Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
                return result;
            }
        }
    }
}