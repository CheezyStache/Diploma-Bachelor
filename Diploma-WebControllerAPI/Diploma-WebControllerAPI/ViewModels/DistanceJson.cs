using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma_WebControllerAPI.Models;

namespace Diploma_WebControllerAPI.ViewModels
{
    public class DistanceJson
    {
        public string[] destination_addresses { get; set; }
        public string[] origin_addresses { get; set; }
        public string status { get; set; }

        public Rows[] rows { get; set; }

        public class Rows 
        {
            public Elements[] elements { get; set; }

            public class Elements
            {
                public Distance distance { get; set; }
                public Distance duration { get; set; }
                public string status { get; set; }

                public class Distance
                {
                    public string text { get; set; }
                    public double value { get; set; }
                }
            }
        }
    }
}
