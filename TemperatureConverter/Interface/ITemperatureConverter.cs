using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureConverter.Enum;

namespace TemperatureConverter.Interface
{
    internal interface ITemperatureConverter
    {
        public TemperatureUnit ReadConvertUnit(string baseUnit);

        public bool IsInputValid(string baseValue, TemperatureUnit baseUnit, TemperatureUnit targetUnit);

        public decimal Process(string baseUnitValue, TemperatureUnit baseUnitEnum, TemperatureUnit targetUnitEnum);
    }
}
