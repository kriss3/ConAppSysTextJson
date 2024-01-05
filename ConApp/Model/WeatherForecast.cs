using System;

namespace ConApp.Model;

public record WeatherForecast(DateTimeOffset Date, int TemperatureCelsius, string? Summary);