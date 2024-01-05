using System.Collections.Concurrent;
using System.Text.Json;

namespace ConApp.Helper;
public static class JsonSerializeOptionsCache
{
    private static readonly ConcurrentDictionary<string, JsonSerializerOptions> Cache = new();

    public static JsonSerializerOptions GetOrAdd(string key, JsonSerializerOptions options)
    {
        return Cache.GetOrAdd(key, options);
    }
}
