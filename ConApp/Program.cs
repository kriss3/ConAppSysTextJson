using System;
using System.Text.Json;
using static System.Console;

WriteLine("Welcome to JSON using STO");

//string fileName = "WeatherForecast.json";

WeatherForecast weatherForecast = 
    new(DateTime.Parse("2023-11-27"), 2, "Cold");

var jsonString = JsonSerializer.Serialize<WeatherForecast>(weatherForecast);

WriteLine(jsonString);

public record WeatherForecast(DateTimeOffset Date, int TemperatureCelsius, string? Summary);

