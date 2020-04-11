using System;
using System.Collections.Generic;

namespace Diploma_WebControllerAPI.Models
{
    public partial class CountryDailyStatistics
    {
        public CountryDailyStatistics()
        {
            DailyStatistics = new HashSet<DailyStatistics>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CitiesCount { get; set; }
        public long? AvgTime { get; set; }
        public int? AvgPetrolAmount { get; set; }
        public int PetrolAmount { get; set; }
        public int? AvgDynamicChangesCount { get; set; }
        public int DynamicChangesCount { get; set; }
        public int? AvgContainersCount { get; set; }
        public int ContainersCount { get; set; }
        public int UtilitiesCount { get; set; }
        public int RegionsCount { get; set; }
        public int FactoriesCount { get; set; }

        public virtual ICollection<DailyStatistics> DailyStatistics { get; set; }
    }
}
