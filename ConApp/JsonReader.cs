using ConApp.Helper;
using ConApp.Model;
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

}
