using ConApp.Model;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConApp;
public static class JsonInvalid
{
    public static bool ReadInvalidJsonFromStream()
    {
        bool result = false;
        var _ = new
        JsonSerializerOptions()
        {
            AllowTrailingCommas = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };

        WeatherForecast weatherForecast = new(DateTime.Parse("2023-11-27"), 2, "Cold");
        var jsonString = JsonSerializer.Serialize(weatherForecast);

        if (string.IsNullOrEmpty(jsonString))
            result = true;
        return result;
    }   
}
