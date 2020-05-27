using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diploma_WebControllerAPI.DataGenerator;

namespace Diploma_WebControllerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeDataController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            var cityGenerator = new CityGenerator();
            if (!cityGenerator.Generate())
                return "Error";

            var factoryGenerator = new FactoryGenerator();
            if(!factoryGenerator.Generate())
                return "Error";

            var utilityGenerator = new UtilityGenerator();
            if (!utilityGenerator.Generate())
                return "Error";

            var regionGenerator = new RegionGenerator();
            if (!regionGenerator.Generate())
                return "Error";

            var containerGenerator = new ContainerGenerator();
            if (!containerGenerator.Generate())
                return "Error";

            var tripGenerator = new TripGenerator();
            if (!tripGenerator.Generate())
                return "Error";

            return "Success";
        }
    }
}