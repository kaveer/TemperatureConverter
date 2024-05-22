// Beginner: Temperature Converter
// Create a console application that converts temperatures between Celsius, Fahrenheit, and Kelvin.

// See https://aka.ms/new-console-template for more information


using TemperatureConverter.Enum;

var converter = new TemperatureConverter.TemperatureDataService();

Console.WriteLine("====== Welcome to temperature converter ======");
Console.WriteLine("Enter the temprature unit to convert from: ");
Console.WriteLine("         1 - Celsius");
Console.WriteLine("         2 - Fahrenheit");
Console.WriteLine("         3 - Kelvin");

var baseUnit = Console.ReadLine();
TemperatureUnit BaseUnitEnum = converter.ReadConvertUnit(baseUnit);
Console.WriteLine("Enter base temparature value: ");
var baseUnitValue = Console.ReadLine();

Console.WriteLine("Enter the temprature unit to convert to: ");
Console.WriteLine("         1 - Celsius");
Console.WriteLine("         2 - Fahrenheit");
Console.WriteLine("         3 - Kelvin");

var targetUnit = Console.ReadLine();
TemperatureUnit targetUnitEnum = converter.ReadConvertUnit(targetUnit);

if(!converter.IsInputValid(baseUnitValue, BaseUnitEnum, targetUnitEnum))
{
    Console.WriteLine("Invalid temperature input");
    Environment.Exit(0);
}

var result = converter.Process(baseUnitValue, BaseUnitEnum, targetUnitEnum);

Console.WriteLine($"Converted temperature from {BaseUnitEnum.ToString()} to {targetUnitEnum.ToString()} is {result}");





