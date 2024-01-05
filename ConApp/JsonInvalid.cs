using ConApp.Helper;
using ConApp.Model;
using System.IO;
using System.Text.Json;

namespace ConApp;
public static class JsonInvalid
{
    public static bool ReadInvalidJsonFromStream(string myFaultyJsonFile)
    {
        bool result = false;

        string jsonString = File.ReadAllText(myFaultyJsonFile);


        JsonSerializerOptions options = new() 
        {
            AllowTrailingCommas = true,
            ReadCommentHandling = JsonCommentHandling.Skip
        };

        // Retrieve the cached JsonSerializeOptions instance
        JsonSerializerOptions cachedOptions = JsonSerializeOptionsCache.GetOrAdd("myKey", options);


        var data = JsonSerializer.Deserialize<WeatherForecast>(jsonString, cachedOptions);

        return data is not null || result;
    }   
}
