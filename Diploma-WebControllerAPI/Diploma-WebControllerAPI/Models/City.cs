using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diploma_WebControllerAPI.Models
{
    public partial class City
    {
        public City()
        {
            DailyStatistics = new HashSet<DailyStatistics>();
            Region = new HashSet<Region>();
        }

        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public long Population { get; set; }

        public virtual ICollection<DailyStatistics> DailyStatistics { get; set; }
        public virtual ICollection<Region> Region { get; set; }
    }
}
