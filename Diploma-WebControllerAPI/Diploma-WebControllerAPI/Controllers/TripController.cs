using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diploma_WebControllerAPI.Models;
using Diploma_WebControllerAPI.TSP;

namespace Diploma_WebControllerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private DiplomaDBContext diplomaDBContext;

        [HttpGet("trip/{regionId}")]
        public string BuildTripByRegion(int regionId)
        {
            using(diplomaDBContext = new DiplomaDBContext())
            {
                //var containers = diplomaDBContext.Container.Where(c => c.RegionId == regionId).Where(c => c.Full).ToArray();
                var containers = diplomaDBContext.Container.Where(c => c.RegionId == regionId).ToArray();

                GA_TSP tsp = new GA_TSP(containers);
                tsp.Initialization();
                var indexes = tsp.TSPCompute();

                var tripContainers = new List<Container>();

                string containerIndexes = "[ ";

                for(int i = 0; i < indexes.Length; i++)
                {
                    tripContainers.Add(containers[indexes[i]]);
                    containerIndexes += indexes[i].ToString() + ", ";
                }

                containerIndexes += "]";

                return containerIndexes;
            }
        }
    }
}