using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diploma_WebControllerAPI.Models
{
    public partial class Region
    {
        public Region()
        {
            Container = new HashSet<Container>();
            RegionDailyStatistics = new HashSet<RegionDailyStatistics>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public long Population { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Map { get; set; }
        public int UtilityId { get; set; }
        public int RecycleFactoryId { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual RecycleFactory RecycleFactory { get; set; }
        public virtual Utility Utility { get; set; }
        public virtual ICollection<Container> Container { get; set; }
        public virtual ICollection<RegionDailyStatistics> RegionDailyStatistics { get; set; }
    }
}
