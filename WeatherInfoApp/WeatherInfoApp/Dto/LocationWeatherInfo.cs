using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherInfoApp.Dto
{
    internal class LocationWeatherInfo
    {
        string Name { get; set; }
        GeoCoordinate Coordinate { get; set; }
        double Temperature { get; set; }
        double WindStrength { get; set; }
        double Humidity { get; set; }
    }
}
