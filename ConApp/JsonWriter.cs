using ConApp.Model;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConApp;
public static class JsonWriter
{
    public static async Task WriteJsonToStream(string myFileName)
    {
        WeatherForecast weatherForecast = new(DateTime.Parse("2023-11-27"), 2, "Very Cold");
        
        using FileStream createStream = File.Create(myFileName);

        await JsonSerializer.SerializeAsync(createStream, weatherForecast);

        await createStream.DisposeAsync();
    }

    public static bool WriteToJsonFile(string myFileName) 
    {
        bool result = false;

        WeatherForecast weatherForecast = new(DateTime.Parse("2023-11-27"), 2, "Very Cold");

        string jsonString = JsonSerializer.Serialize(weatherForecast);

        if (!string.IsNullOrEmpty(jsonString))
        {
            File.WriteAllText(@$"Data/{myFileName}", jsonString);
            result = true;
        }

        return result;
    }
}
