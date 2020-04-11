using System;
using System.Collections.Generic;

namespace Diploma_WebControllerAPI.Models
{
    public partial class CityUtilities
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int UtilityId { get; set; }

        public virtual City City { get; set; }
        public virtual Utility Utility { get; set; }
    }
}
