using ConApp.Helper;
using ConApp.Model;
using System;
using System.IO;
using System.Text.Json;

namespace ConApp;
public static class JsonReader
{
    public static bool ReadJsonFromStream(string myJsonFile) 
    {
        bool result = false;

        string jsonString = File.ReadAllText(myJsonFile);

        JsonSerializerOptions options = new()
        {
            AllowTrailingCommas = true,
            ReadCommentHandling = JsonCommentHandling.Skip
        };

        JsonSerializerOptions cachedOptions = JsonSerializeOptionsCache.GetOrAdd("myKey", options);

        WeatherForecast? data = JsonSerializer.Deserialize<WeatherForecast>(jsonString, cachedOptions);

        return data is not null || result;
    }

    public static bool ReadJsonWithAnnotations(string myJsonFile) 
    {
        WeatherForecast_v2 weatherForecast = new()
        {
            Date = DateTime.Parse("204-01-11"),
            TemperatureCelsius = 2,
            Summary = "Cold",
            WindSpeed = 30,
        };

        JsonSerializerOptions serializeOption = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
        };

        var jsonResult = JsonSerializer.Serialize(weatherForecast);
        return true;
    }
}
