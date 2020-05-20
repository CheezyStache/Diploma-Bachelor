using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diploma_WebControllerAPI.TSP;

namespace Diploma_WebControllerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TSPController : ControllerBase
    {
        public string Index()
        {
            GA_TSP tsp = new GA_TSP();
            tsp.Initialization();
            tsp.TSPCompute();

            return "success";
        }
    }
}