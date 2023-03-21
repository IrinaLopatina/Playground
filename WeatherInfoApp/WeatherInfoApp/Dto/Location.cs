using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherInfoApp.Dto
{
    internal class Location
    {
        string Name { get; set; }
        GeoCoordinate Coordinate { get; set; }
        string Url { get; set; }
    }
}
