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
using Microsoft.EntityFrameworkCore;

namespace Diploma_WebControllerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly HttpClient client = new HttpClient();
        private DiplomaDBContext diplomaDBContext;

        [HttpGet("region/{regionId}")]
        public async Task<string> ActivateRegion(int regionId)
        {
            using (diplomaDBContext = new DiplomaDBContext())
            {
                var regionsCount = diplomaDBContext.Region.Count();
                var distanceCount = diplomaDBContext.Distance.Count();
                var containerDistanceCount = diplomaDBContext.ContainerDistances.Count();

                var containers = diplomaDBContext.Container.Where(c => c.RegionId == regionId).OrderBy(c => c.Ready).ToArray();
                var locations = diplomaDBContext.Container.Where(c => c.RegionId == regionId).OrderBy(c => c.Ready).Select(c => c.Location).ToArray();
                var utility = diplomaDBContext.Region.Include(r => r.Utility).ThenInclude(u => u.Location).Where(r => r.Id == regionId).Select(r => r.Utility).SingleOrDefault();
                var factory = diplomaDBContext.Region.Include(r => r.RecycleFactory).ThenInclude(f => f.Location).Where(r => r.Id == regionId).Select(r => r.RecycleFactory).SingleOrDefault();

                var notReadyContainersCount = diplomaDBContext.Container.Where(c => c.RegionId == regionId && !c.Ready).Count();

                await GetDistance(notReadyContainersCount, distanceCount, containerDistanceCount, locations, containers, utility, factory, diplomaDBContext);

                try
                {
                    //System.Diagnostics.Debug.WriteLine("distanceCount: " + distanceCount);
                    diplomaDBContext.SaveChanges();
                    return "1";
                }
                catch
                {
                    return "0";
                }
            }
        }

        private async Task GetDistance(int notReadyContainersCount, int distanceCount, int containerDistanceCount, Models.Location[] locations, Models.Container[] containers,
                        Models.Utility utility, Models.RecycleFactory factory, DiplomaDBContext diplomaDBContext)
        {
            for (int j = 0; j < notReadyContainersCount; j++)
            {
                var containerLocation = locations[j];

                for (int k = j + 1; k < containers.Length; k++)
                {
                    var distanceJson = await DistanceRequest(containerLocation, locations[k]);

                    await AddElements(distanceCount, containerDistanceCount, distanceJson, containers[j].Id, containers[k].Id, diplomaDBContext);
                    distanceCount++;
                    containerDistanceCount += 2;
                }

                var utilityDistanceJson = await DistanceRequest(containerLocation, utility.Location);

                await AddElements(distanceCount, containerDistanceCount, utilityDistanceJson, containers[j].Id, utility.Id, diplomaDBContext, utility: true);
                distanceCount++;
                containerDistanceCount += 2;

                var factoryDistanceJson = await DistanceRequest(containerLocation, factory.Location);

                await AddElements(distanceCount, containerDistanceCount, factoryDistanceJson, containers[j].Id, factory.Id, diplomaDBContext, factory: true);
                distanceCount++;
                containerDistanceCount += 2;

                containers[j].Ready = true;
            }

            var utilityFactoryDistanceJson = await DistanceRequest(utility.Location, factory.Location);
            await AddElements(distanceCount, containerDistanceCount, utilityFactoryDistanceJson, factory.Id, utility.Id, diplomaDBContext, true, true);
        }

        private async Task<DistanceJson> DistanceRequest(Models.Location locationFrom, Models.Location locationTo)
        {
            var secondContainerLocation = locationTo;
            var response = await client.GetStringAsync("https://maps.googleapis.com/maps/api/distancematrix/json?origins="
            + locationFrom.Latitude.ToString(CultureInfo.InvariantCulture)
            + "," + locationFrom.Longitude.ToString(CultureInfo.InvariantCulture)
            + "&destinations=" + secondContainerLocation.Latitude.ToString(CultureInfo.InvariantCulture)
            + "," + secondContainerLocation.Longitude.ToString(CultureInfo.InvariantCulture) + "&mode=driving&key=AIzaSyA5DGX196CfHT3HcxrDF_qg1oBDqG9-KqE");

            var distanceJson = JsonSerializer.Deserialize<DistanceJson>(response);

            return distanceJson;
        }

        private async Task AddElements(int distanceCount, int containerDistanceCount, DistanceJson distanceJson, int firstContId, int secondContId,
                        DiplomaDBContext diplomaDBContext, bool utility = false, bool factory = false)
        {
            var distance = new Distance
            {
                Id = ++distanceCount,
                Value = distanceJson.rows[0].elements[0].distance.value
            };

            ContainerDistance containerDistanceFirst;
            if (utility && factory)
                containerDistanceFirst = new ContainerDistance
                {
                    Id = ++containerDistanceCount,
                    DistanceId = distanceCount,
                    RecycleFactoryId = (int?)firstContId
                };
            else
                containerDistanceFirst = new ContainerDistance
                {
                    Id = ++containerDistanceCount,
                    DistanceId = distanceCount,
                    ContainerId = (int?)firstContId
                };

            ContainerDistance containerDistanceSecond;
            if (utility)
                containerDistanceSecond = new ContainerDistance
                {
                    Id = ++containerDistanceCount,
                    DistanceId = distanceCount,
                    UtilityId = (int?)secondContId
                };
            else if (factory)
                containerDistanceSecond = new ContainerDistance
                {
                    Id = ++containerDistanceCount,
                    DistanceId = distanceCount,
                    RecycleFactoryId = (int?)secondContId
                };
            else
                containerDistanceSecond = new ContainerDistance
                {
                    Id = ++containerDistanceCount,
                    DistanceId = distanceCount,
                    ContainerId = (int?)secondContId
                };

            diplomaDBContext.Distance.Add(distance);
            diplomaDBContext.ContainerDistances.Add(containerDistanceFirst);
            diplomaDBContext.ContainerDistances.Add(containerDistanceSecond);

            await Task.Delay(500);
        }
    }
}