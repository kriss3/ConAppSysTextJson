
using System.Collections.Generic;
using Functional;

namespace ConApp.Model;



public record MonkeyAggr 
{
    public string? Source { get; init; }
    public IEnumerable<Monkey> Monkeys { get; init; } = new List<Monkey>();
}

public record Monkey
{
    public Name? Name { get; init; }
    public string? Location { get; init; }
    public string? Details { get; init; }
    public string? Image { get; init; }
    public int? Population { get; init; }
    public float? Latitude { get; init; }
    public float? Longitude { get; init; }
}


public record Name
{
    private string _value;

    private Name(string value)
    {
        _value = value;
    }

    public static Option<Name> Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Name cannot be null or empty.");
        }

        return new Name(value);
    }
}

