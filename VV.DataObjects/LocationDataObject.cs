using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VV.DataObjects
{
    public class LocationDataObject
    {
        public string Id { get; set; }

        public string Location
        {
            get;
            set;
        }

        public long Latitude { get; set; }
        public long Longitude { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }


    }
}
