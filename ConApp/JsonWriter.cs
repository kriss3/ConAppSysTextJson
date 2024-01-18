using ConApp.Model;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
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

    /// <summary>
    /// This is a 4th episode of James Montagno's series on System.Text.Json. 
    /// Ignoring Properties when reading & writing JSON.
    /// </summary>
    /// <param name="myFileName">A file to serialize to</param>
    /// <returns>Success or Failure of Serialization</returns>
    public static bool WriteToJsonFile_OmitProperties(string myFileName)
    {
        bool result = false;

        WeatherForecast_v2 weatherForecast = new()
        {
            Date = DateTime.Parse("2023-11-27"),
            Summary = null,
            TemperatureCelsius = default,
            WindSpeed = 10
        };

        JsonSerializerOptions options = new() 
        {
            WriteIndented = true,
            IgnoreReadOnlyProperties = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault & JsonIgnoreCondition.WhenWritingNull
        }; 

        string jsonString = JsonSerializer.Serialize(weatherForecast, options);

        if (!string.IsNullOrEmpty(jsonString))
        {
            File.WriteAllText(@$"Data/{myFileName}", jsonString);
            result = true;
        }

        return result;
    }
}
