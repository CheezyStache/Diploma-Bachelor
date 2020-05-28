using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Diploma_WebControllerAPI.Models;
using System.Text.Json;
using Diploma_WebControllerAPI.ViewModels;
using System.Globalization;

namespace Diploma_WebControllerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly HttpClient client = new HttpClient();
        private DiplomaDBContext diplomaDBContext;

        public async Task<string> Index()
        {
            using(diplomaDBContext = new DiplomaDBContext())
            {
                var regionsCount = diplomaDBContext.Region.Count();
                var distanceCount = diplomaDBContext.Distance.Count();
                var containerDistanceCount = diplomaDBContext.ContainerDistances.Count();

                //System.Diagnostics.Debug.WriteLine("distanceCount: " + distanceCount);

                for(int i = 0; i < regionsCount; i++)
                {
                    var containers = diplomaDBContext.Container.Where(c => c.RegionId == i + 1).ToArray();
                    var locations = diplomaDBContext.Container.Where(c => c.RegionId == i + 1).Select(c => c.Location).ToArray();

                    for(int j = 0; j < containers.Length; j++)
                    {
                        var containerLocation = locations[j];

                        for(int k = j + 1; k < containers.Length; k++)
                        {
                            var secondContainerLocation = locations[k];
                            var response = await client.GetStringAsync("https://maps.googleapis.com/maps/api/distancematrix/json?origins=" 
                            + containerLocation.Latitude.ToString(CultureInfo.InvariantCulture)
                            + "," + containerLocation.Longitude.ToString(CultureInfo.InvariantCulture)
                            + "&destinations=" + secondContainerLocation.Latitude.ToString(CultureInfo.InvariantCulture) 
                            + "," + secondContainerLocation.Longitude.ToString(CultureInfo.InvariantCulture) +"&mode=driving&key=AIzaSyA5DGX196CfHT3HcxrDF_qg1oBDqG9-KqE");

                            var distanceJson = JsonSerializer.Deserialize<DistanceJson>(response);

                            //System.Diagnostics.Debug.WriteLine("test: " + response);

                            var distance = new Distance
                            {
                                Id = ++distanceCount,
                                Value = distanceJson.rows[0].elements[0].distance.value
                            };

                            var containerDistanceFirst = new ContainerDistance
                            {
                                Id = ++containerDistanceCount,
                                DistanceId = distanceCount,
                                ContainerId = containers[j].Id
                            };

                            var containerDistanceSecond = new ContainerDistance
                            {
                                Id = ++containerDistanceCount,
                                DistanceId = distanceCount,
                                ContainerId = containers[k].Id
                            };

                            diplomaDBContext.Distance.Add(distance);
                            diplomaDBContext.ContainerDistances.Add(containerDistanceFirst);
                            diplomaDBContext.ContainerDistances.Add(containerDistanceSecond);

                            await Task.Delay(500);
                        }
                    }
                }

                try
                {
                    //System.Diagnostics.Debug.WriteLine("distanceCount: " + distanceCount);
                    diplomaDBContext.SaveChanges();
                    return "success";
                }
                catch
                {
                    return "error";
                }
            }
        }
    }
}