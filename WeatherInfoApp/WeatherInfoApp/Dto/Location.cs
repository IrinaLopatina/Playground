using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherInfoApp.Dto
{
    public class Location
    {
        public string Name { get; set; }
        public GeoCoordinate Coordinate { get; set; }
        public string Url { get; set; }
    }
}
