﻿using System;

namespace WeatherInfoApp.Dto
{
    public class LocationWeatherInfo
    {
        public string Name { get; set; }
        public GeoCoordinate Coordinate { get; set; }
        public double Temperature { get; set; }
        public double WindStrength { get; set; }
        public double Humidity { get; set; }
        public DateTime DateTime { get; set; }
    }
}
