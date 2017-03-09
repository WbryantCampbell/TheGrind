using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace MyFirstWebService.Models
{
    [XmlRoot("StockQuotes", Namespace = "", IsNullable = false)]
    public class StockQuotes
    {
       [XmlElement("Stock")]
       public Stock[] Stocks { get; set; }

    }
}
