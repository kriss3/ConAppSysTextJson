using System;
using System.Text.Json.Serialization;

namespace ConApp.Model;
public class WeatherForecast_v2
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureCelsius { get; set; }
    public string Summary { get; set; } = string.Empty;
    [JsonPropertyName("wind")]
    public int WindSpeed { get; set; }
}
