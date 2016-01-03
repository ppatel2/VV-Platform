using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VV.DataObjects
{
     public class TenantDataObject
     {
          public int Id { get; set; }
          public string Name { get; set; }
          public string SubDomain { get; set; }
          public string AccountLead { get; set; }
          
     }
}