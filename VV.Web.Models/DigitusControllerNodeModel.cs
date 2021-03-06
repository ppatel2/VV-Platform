﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VV.Web.Models
{
    [DataContract]
    public class DigitusControllerNodeModel
    {
        [DataMember]
        public Guid ControllerGuid { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int NodeSerialNumber { get; set; }

    }
}
