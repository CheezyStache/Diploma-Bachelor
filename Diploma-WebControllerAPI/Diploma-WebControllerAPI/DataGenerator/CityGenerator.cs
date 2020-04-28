using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma_WebControllerAPI.Models;

namespace Diploma_WebControllerAPI.DataGenerator
{
    public class CityGenerator
    {
        public bool Generate()
        {
            var cities = new List<City>();
            cities.Add(new City { Id = 1, Name = "Київ", Population = 2884974 });
            cities.Add(new City { Id = 2, Name = "Львів", Population = 721301 });
            cities.Add(new City { Id = 3, Name = "Харків", Population = 1419765 });
            cities.Add(new City { Id = 4, Name = "Одеса", Population = 993120 });

            using(var dimplomaDbContext = new DiplomaDBContext())
            {
                if (dimplomaDbContext.City.Count() == cities.Count)
                    return true;

                dimplomaDbContext.City.AddRange(cities);
                var result = dimplomaDbContext.SaveChanges();
                return result > 0;
            }

        }
    }
}
