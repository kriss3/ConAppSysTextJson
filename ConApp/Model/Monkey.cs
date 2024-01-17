
using System.Collections.Generic;

namespace ConApp.Model;


public record MonkeyAggr 
{
    public string? Source { get; init; }
    public IEnumerable<Monkey> Monkeys { get; init; } = new List<Monkey>();
}

public record Monkey
{
    public string? Name { get; init; }
    public string? Location { get; init; }
    public string? Details { get; init; }
    public string? Image { get; init; }
    public int? Population { get; init; }
    public float? Latitude { get; init; }
    public float? Longitude { get; init; }
}
