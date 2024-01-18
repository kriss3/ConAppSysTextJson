using System;
using System.Text.Json.Serialization;

namespace ConApp.Model;
public class WeatherForecast_v2
{
    [JsonIgnore(Condition =JsonIgnoreCondition.Never)]
    public DateTimeOffset Date { get; set; }
    public int TemperatureCelsius { get; set; }

    [JsonIgnore]
    public string? Summary { get; set; } = string.Empty;
    
    [JsonPropertyName("wind")]
    public int WindSpeed { get; set; }
    public int WindSpeedReadOnly { get; private set; } = 35;
}

/*
 * To ignore a property you can add an attribute to it. See the Summary prop. Attribute will take of reading and writing.
 * 
 * You can also ignore globally all readonly properties. In this case, use JsonSerializerOptions.
 * 
 * When you want to ignore default and/or NULL then model is serialized you can use DefaultIgnoreCondition (this is enum)
 * 
 * Another way to add Condition is to add Annotation to the property. See the Date prop.
 * 
 * When using JsonSerlizerOptions this is a default setup. When you use attributes for individual properties, they will override the global settings.
 * 
 * There is also and Option call JsonIgnoreCondition.Always. This is throw exception if used in the JsonSerializerOptions: 'The value cannot be JsonIgnoreCondition.Always'. 
 * When used for individual properties, that property will be ignored.
 */
