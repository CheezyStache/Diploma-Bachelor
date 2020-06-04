using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diploma_WebControllerAPI.Models
{
    public partial class RecycleFactory
    {
        public RecycleFactory()
        {
            Region = new HashSet<Region>();
        }

        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public bool Ready { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Region> Region { get; set; }
    }
}
