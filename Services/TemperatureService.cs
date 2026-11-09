using System;
using TemperatureBlazorApp.Models;

namespace TemperatureBlazorApp.Services
{
    public class TemperatureService
    {
        public TemperatureResult Convert(double value, TemperatureScale fromScale)
        {
            double kelvin = fromScale switch
            {
                TemperatureScale.Celsius => value + 273.15,
                TemperatureScale.Fahrenheit => (value - 32) * 5.0 / 9.0 + 273.15,
                TemperatureScale.Kelvin => value,
                _ => throw new ArgumentException("INVALID_SCALE")
            };

            if (kelvin < 0)
            {
                throw new ArgumentException("INVALID_TEMPERATURE: Температура ниже абсолютного нуля!");
            }

            return new TemperatureResult
            {
                Celsius = Math.Round(kelvin - 273.15, 2),
                Fahrenheit = Math.Round((kelvin - 273.15) * 1.8 + 32, 2),
                Kelvin = Math.Round(kelvin, 2)
            };
        }
    }
}
