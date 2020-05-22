using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Diploma_WebControllerAPI.Models;
using Diploma_WebControllerAPI.ViewModels;

namespace Diploma_WebControllerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private DiplomaDBContext diplomaDBContext;

        private readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            IgnoreNullValues = true
        };

        [HttpGet("containers")]
        public string GetAllContainers()
        {
            var result = "";

            using (diplomaDBContext = new DiplomaDBContext())
            {
                var containers = diplomaDBContext.Container.ToArray();

                var containersLocation = new ContainerLocation[containers.Length];
                for(int i = 0; i < containersLocation.Length; i++)
                {
                    var location = new Diploma_WebControllerAPI.ViewModels.Location
                    {
                        Latitude = diplomaDBContext.Location.Single(l => l.Id == containers[i].LocationId).Latitude,
                        Longitude = diplomaDBContext.Location.Single(l => l.Id == containers[i].LocationId).Longitude
                    };

                    containersLocation[i] = new ContainerLocation
                    {
                        Id = containers[i].Id,
                        Full = containers[i].Full,
                        LastGather = containers[i].LastGather,
                        LastUpdate = containers[i].LastUpdate,
                        Region = diplomaDBContext.Region.Single(l => l.Id == containers[i].RegionId).Name,
                        Location = location
                    };
                }

                result = JsonSerializer.Serialize(containersLocation, JsonOptions);
            }

            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
            return result;
        }

        [HttpGet("factories")]
        public string GetAllFactories()
        {
            var result = "";

            using (diplomaDBContext = new DiplomaDBContext())
            {
                var factories = diplomaDBContext.RecycleFactory.ToArray();

                var factoryLocation = new FactoryLocation[factories.Length];
                for (int i = 0; i < factoryLocation.Length; i++)
                {
                    var location = new Diploma_WebControllerAPI.ViewModels.Location
                    {
                        Latitude = diplomaDBContext.Location.Single(l => l.Id == factories[i].LocationId).Latitude,
                        Longitude = diplomaDBContext.Location.Single(l => l.Id == factories[i].LocationId).Longitude
                    };

                    var region = diplomaDBContext.Region.FirstOrDefault(r => r.RecycleFactoryId == factories[i].Id);

                    factoryLocation[i] = new FactoryLocation
                    {
                        Id = factories[i].Id,
                        Name = factories[i].Name,
                        Ready = factories[i].Ready,
                        Region = region == null ? "" : region.Name,
                        Location = location
                    };
                }

                result = JsonSerializer.Serialize(factoryLocation, JsonOptions);
            }

            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
            return result;
        }

        [HttpGet("utilities")]
        public string GetAllUtilities()
        {
            var result = "";

            using (diplomaDBContext = new DiplomaDBContext())
            {
                var utilities = diplomaDBContext.Utility.ToArray();

                var utilityLocation = new UtilityLocation[utilities.Length];
                for (int i = 0; i < utilityLocation.Length; i++)
                {
                    var location = new Diploma_WebControllerAPI.ViewModels.Location
                    {
                        Latitude = diplomaDBContext.Location.Single(l => l.Id == utilities[i].LocationId).Latitude,
                        Longitude = diplomaDBContext.Location.Single(l => l.Id == utilities[i].LocationId).Longitude
                    };

                    utilityLocation[i] = new UtilityLocation
                    {
                        Id = utilities[i].Id,
                        Name = utilities[i].Name,
                        Ready = utilities[i].Ready,
                        Regions = diplomaDBContext.Region.Where(r => r.UtilityId == utilities[i].Id).Select(r => r.Name).ToArray(),
                        Location = location
                    };
                }

                result = JsonSerializer.Serialize(utilityLocation, JsonOptions);
            }

            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
            return result;
        }
    }
}