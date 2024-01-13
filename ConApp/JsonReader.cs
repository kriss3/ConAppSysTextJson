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

        //TO-DO: reuse caching implemented in the Helper folder
        JsonSerializerOptions serializeOption = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
        };

        JsonSerializerOptions serializeOptions_v2 = new()
        {
            PropertyNamingPolicy = new MakeAllCapsJsonPolicy(),
            WriteIndented = true,
        };

        var jsonResult = JsonSerializer.Serialize(weatherForecast, serializeOption);

        var jsonResult_v2 = JsonSerializer.Serialize(weatherForecast, serializeOptions_v2);

        return string.IsNullOrEmpty(jsonResult);
    }
}

public class MakeAllCapsJsonPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        return name.ToUpper();
    }
}
