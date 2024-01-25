

using ConAppGetDataFromTheWeb;
using System.Text.Json;

WriteLine("Get Monkeys from Internet!");

List<Monkey> monkeyList;

monkeyList = await GetMonkeys();

async Task<List<Monkey>> GetMonkeys() 
{

    HttpClient _client = new();
    var myJson = await _client.GetStringAsync("https://www.montemagno.com/monkeys.json");
    monkeyList = JsonSerializer.Deserialize<List<Monkey>>(myJson) ?? [];
    return monkeyList;
}