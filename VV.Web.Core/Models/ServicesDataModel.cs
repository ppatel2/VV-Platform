using VV.Web.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VV.Web.Core.Models
{
     public class ServicesDataModel
     {
          public List<string> Services { get; set; }
          public List<string> Statuses { get; set; }

          public ServicesDataModel()
          {
               this.Services = new List<string>();
               this.Statuses = new List<string>();
               ServicesDataAccess sda = new ServicesDataAccess();
               foreach (var service in sda.Services)
               {
                    this.Services.Add(service.Key);
                    this.Statuses.Add(service.Value);
               }
          }

     }
}