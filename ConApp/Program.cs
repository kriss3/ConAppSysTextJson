using ConApp;
using static System.Console;

WriteLine("Welcome to JSON using S.T.J.");

string fileNameToOperate = "WeatherForecast.json";

var _ = JsonWriter.WriteToJsonFile(fileNameToOperate);

//TO-DO => Check if file exists before reading...
var __ = JsonReader.ReadJsonFromStream(fileNameToOperate);

WriteLine("Done!!");

