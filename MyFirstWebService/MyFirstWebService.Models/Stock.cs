using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace MyFirstWebService.Models
{
    public class Stock
    {
        [XmlAnyElement("Symbol")]
        public string Symbol { get; set; }
        [XmlAnyElement("Name")]
        public string Name { get; set; }
        [XmlAnyElement("Last")]
        public decimal Last { get; set; }
        [XmlAnyElement("PercentageChange")]
        public decimal PercentageChange { get; set; }
        [XmlAnyElement("AnnRange")]
        public string AnnRange { get; set; }

    }
}
