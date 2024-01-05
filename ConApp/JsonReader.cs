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

        WeatherForecast? data = JsonSerializer.Deserialize<WeatherForecast>(jsonString, options);

        return data is not null || result;
    }

}
