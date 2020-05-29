using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Diploma_WebControllerAPI.SaveModels;
using Diploma_WebControllerAPI.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;

namespace Diploma_WebControllerAPI.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class SaveController : ControllerBase
    {
        [HttpPost("region")]
        public int SaveRegion(RegionSaveModel regionSaveModel)
        {
            try
            {
                using(var dbContext = new DiplomaDBContext())
                {
                    var region = new Region
                    {
                        Id = dbContext.Region.Count() + 1,
                        Name = regionSaveModel.name,
                        Population = regionSaveModel.population.HasValue ? regionSaveModel.population.Value : 0,
                        Map = JsonSerializer.Serialize<LatLng[]>(regionSaveModel.path),
                        UtilityId = regionSaveModel.utility,
                        RecycleFactoryId = regionSaveModel.sortStation,
                        CityId = regionSaveModel.city
                    };

                    dbContext.Region.Add(region);
                    dbContext.SaveChanges();

                    return 1;
                }
            }
            catch
            {
                return 0;
            }
        }

        [HttpPost("container")]
        public int SaveContainer(ContainerSaveModel containerSaveModel)
        {
            try
            {
                using(var dbContext = new DiplomaDBContext())
                {
                    var locationId = dbContext.Location.Count() + 1;
                    var containerId = dbContext.Container.Count() + 1;

                    var location = new Location
                    {
                        Id = locationId,
                        Latitude = containerSaveModel.location.lat,
                        Longitude = containerSaveModel.location.lng
                    };

                    var container = new Container
                    {
                        Id = containerId,
                        Code = containerSaveModel.code,
                        LocationId = locationId,
                        Full = false,
                        RegionId = containerSaveModel.region
                    };

                    dbContext.Location.Add(location);
                    dbContext.Container.Add(container);
                    dbContext.SaveChanges();

                    return 1;
                }
            }
            catch
            {
                return 0;
            }
        }

        [HttpPost("building")]
        public int SaveBuilding(BuildingSaveModel buildingSaveModel)
        {
            try
            {
                using(var dbContext = new DiplomaDBContext())
                {
                    var locationId = dbContext.Location.Count() + 1;

                    var location = new Location
                    {
                        Id = locationId,
                        Latitude = buildingSaveModel.location.lat,
                        Longitude = buildingSaveModel.location.lng
                    };

                    dbContext.Location.Add(location);

                    if(buildingSaveModel.type == 0)
                    {
                        var utilityId = dbContext.Utility.Count() + 1;
                        var utility = new Utility
                        {
                            Id = utilityId,
                            Name = buildingSaveModel.name,
                            LocationId = locationId,
                            Ready = buildingSaveModel.ready,
                            UtilityCompanyId = buildingSaveModel.utilityCompany.Value,
                            UtilityOptionsId = 1
                        };

                        dbContext.Utility.Add(utility);
                    }
                    else
                    {
                        var factoryId = dbContext.RecycleFactory.Count() + 1;
                        var factory = new RecycleFactory
                        {
                            Id = factoryId,
                            Name = buildingSaveModel.name,
                            LocationId = locationId,
                            Ready = buildingSaveModel.ready
                        };

                        dbContext.RecycleFactory.Add(factory);
                    }
                    
                    dbContext.SaveChanges();

                    return 1;
                }
            }
            catch
            {
                return 0;
            }
        }

        [HttpPost("utilityCompany")]
        public int SaveUtilityCompany(UtilityCompanySaveModel utilityCompanySaveModel)
        {
            try
            {
                using(var dbContext = new DiplomaDBContext())
                {
                    var count = dbContext.UtilityCompany.Count();

                    var utilityCompany = new UtilityCompany
                    {
                        Id = count + 1,
                        Name = utilityCompanySaveModel.name
                    };

                    dbContext.UtilityCompany.Add(utilityCompany);
                    
                    dbContext.SaveChanges();

                    return 1;
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}
