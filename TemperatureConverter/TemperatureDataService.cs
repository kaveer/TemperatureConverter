using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureConverter.Enum;
using TemperatureConverter.Interface;

namespace TemperatureConverter
{
    internal class TemperatureDataService : ITemperatureConverter
    {
        public bool IsInputValid(string baseValue, TemperatureUnit baseUnit, TemperatureUnit targetUnit)
        {

            if (string.IsNullOrEmpty(baseValue))
                return false;

            if (baseUnit == TemperatureUnit.None)
                return false;

            if (targetUnit == TemperatureUnit.None)
                return false;

            if (baseUnit == targetUnit)
                return false;

            if (!decimal.TryParse(baseValue, out _))
                return false;

            return true;
        }

        public TemperatureUnit ReadConvertUnit(string inputUnit)
        {
            if (!int.TryParse(inputUnit, out var unit))
            {
                Console.WriteLine("Invalid temperature unit. Please enter convert unit: ");
                inputUnit = Console.ReadLine();
                ReadConvertUnit(inputUnit);
            }

            return unit switch
            {
                1 => TemperatureUnit.Celcuis,
                2 => TemperatureUnit.Fahrenheit,
                3 => TemperatureUnit.Kelvin,
                _ => TemperatureUnit.None,
            };
        }

        public decimal Process(string baseUnitValue, TemperatureUnit baseUnitEnum, TemperatureUnit targetUnitEnum)
        {//bodmasc
            decimal.TryParse(baseUnitValue, out var parseBaseUnitValue);

            if (baseUnitEnum == TemperatureUnit.Celcuis)
            {
                //Celsius to Kelvin: K = C + 273.15
                if (targetUnitEnum == TemperatureUnit.Kelvin)
                    return parseBaseUnitValue + 273.15m;

                //Celsius to Fahrenheit: F = C(9 / 5) + 32
                if (targetUnitEnum == TemperatureUnit.Fahrenheit)
                    return parseBaseUnitValue * (9m / 5m) + 32;
            }

            if (baseUnitEnum == TemperatureUnit.Fahrenheit)
            {
                //Fahrenheit to Celcius: C = (F - 32)(5 / 9)
                if (targetUnitEnum == TemperatureUnit.Celcuis)
                    return (parseBaseUnitValue - 32) * (5 / 9);

                //Fahrenheit to Kelvin: K = (F - 32)(5 / 9) + 273.15
                if (targetUnitEnum == TemperatureUnit.Kelvin)
                    return (parseBaseUnitValue - 32m) * (5m / 9m) + 273.15m;
            }

            if (baseUnitEnum == TemperatureUnit.Kelvin)
            {
                //Kelvin to Celcius: C = K - 273.15
                if (targetUnitEnum == TemperatureUnit.Celcuis)
                    return parseBaseUnitValue - 273.15m;

                //Kelvin to Fahrenheit: F = (K - 273.15)(9 / 5) + 32
                if (targetUnitEnum == TemperatureUnit.Fahrenheit)
                    return (parseBaseUnitValue - 273.15m) * (9m / 5m) + 32;
            }

            return 0;
        }
    }
}
