using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VV_WebApp.Models
{

    [XmlRoot(ElementName = "parameter")]
    public class Parameter
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string __Text { get; set; }
        [XmlAttribute(AttributeName = "text")]
        public string _Text { get; set; }
        [XmlAttribute(AttributeName = "color")]
        public string Color { get; set; }
    }

    [XmlRoot(ElementName = "parameter_list")]
    public class Parameter_list
    {
        [XmlElement(ElementName = "parameter")]
        public List<Parameter> Parameter { get; set; }
    }

    [XmlRoot(ElementName = "record")]
    public class Record
    {
        [XmlElement(ElementName = "parameter_list")]
        public Parameter_list Parameter_list { get; set; }
    }

    [XmlRoot(ElementName = "record_list")]
    public class Record_list
    {
        [XmlElement(ElementName = "record")]
        public Record Record { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "load")]
    public class Load
    {
        [XmlElement(ElementName = "record_list")]
        public Record_list Record_list { get; set; }
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
    }

}
