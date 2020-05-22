using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma_WebControllerAPI.Models;

namespace Diploma_WebControllerAPI.SaveModels
{
    public class RegionSaveModel
    {
        public string name {get;set;}
        public int? population {get;set;}
        public int utility {get;set;}
        public int sortStation {get;set;}

        public int city {get;set;}

        public LatLng[] path {get;set;}
    }
}