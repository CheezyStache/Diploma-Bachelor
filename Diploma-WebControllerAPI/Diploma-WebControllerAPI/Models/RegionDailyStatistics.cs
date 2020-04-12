using System;
using System.Collections.Generic;

namespace Diploma_WebControllerAPI.Models
{
    public partial class RegionDailyStatistics
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public long? AvgTime { get; set; }
        public int? AvgPetrolAmount { get; set; }
        public int PetrolAmount { get; set; }
        public int? AvgDynamicChangesCount { get; set; }
        public int DynamicChangesCount { get; set; }
        public int? AvgContainersCount { get; set; }
        public int? CollectedContainersCount { get; set; }
        public int ContainersCount { get; set; }
        public int UtilityId { get; set; }
        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
        public virtual Utility Utility { get; set; }
    }
}
