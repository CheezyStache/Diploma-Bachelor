using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma_WebControllerAPI.Models;

namespace Diploma_WebControllerAPI.SaveModels
{
    public class ContainerSaveModel
    {
        public string code {get;set;}
        public string address {get;set;}
        public int region {get;set;}
        public LatLng location {get;set;}
    }
}