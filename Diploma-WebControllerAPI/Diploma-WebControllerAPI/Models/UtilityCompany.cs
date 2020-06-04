using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diploma_WebControllerAPI.Models
{
    public class UtilityCompany
    {
        public UtilityCompany()
        {
            Utility = new HashSet<Utility>();
        }

        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        public virtual ICollection<Utility> Utility { get; set; }
    }
}
