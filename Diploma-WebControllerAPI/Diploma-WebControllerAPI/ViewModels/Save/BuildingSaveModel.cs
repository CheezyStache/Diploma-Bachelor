using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma_WebControllerAPI.Models;

namespace Diploma_WebControllerAPI.SaveModels
{
    public class BuildingSaveModel
    {
        public int type {get;set;}
        public string name {get;set;}
        public string address {get;set;}
        public int? utilityCompany {get;set;}
        public LatLng location {get;set;}
        public bool ready {get;set;}
    }
}