﻿

using ConAppGetDataFromTheWeb;
using System.Text.Json;

WriteLine("Get Monkeys from Internet!");

List<Monkey> monkeyList = [];

_ = await GetMonkeys();
_ = await GetMonkeys_v2();
_ = await GetMonkeys_v3();


async Task<List<Monkey>> GetMonkeys() 
{
    var url = "https://www.montemagno.com/monkeys.json";
    // normally this would be injected and a private read-only version of httpClient would be used.
    HttpClient _client = new();
    
    var myJson = await _client.GetStringAsync(url);
    monkeyList = JsonSerializer.Deserialize<List<Monkey>>(myJson) ?? [];
    return monkeyList;
}

async Task<List<Monkey>> GetMonkeys_v2()
{
    var url = "https://www.montemagno.com/monkeys.json";
    // normally this would be injected and a private read-only version of httpClient would be used.
    HttpClient _client = new();

    HttpResponseMessage request = await _client.GetAsync(url);

    //I don't want to de-serialize if I don't have a successful response
    if (request.IsSuccessStatusCode)
    {
        monkeyList = await request.Content.ReadFromJsonAsync<List<Monkey>>() ?? [];
    }
    else 
    {
        //do something like HttpError handling
    }

    return monkeyList;
}

async Task<List<Monkey>> GetMonkeys_v3()
{
    var url = "https://www.montemagno.com/monkeys.json";
    // normally this would be injected and a private read-only version of httpClient would be used.
    HttpClient _client = new();

    HttpResponseMessage request = await _client.GetAsync(url);

    //I don't want to de-serialize if I don't have a successful response
    if (request.IsSuccessStatusCode)
    {
        monkeyList = await request.Content.ReadFromJsonAsync(MonkeyContext.Default.ListMonkey) ?? [];
    }
    else
    {
        //do something like HttpError handling
    }

    return monkeyList;
}