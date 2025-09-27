using BroadcastPluginSDK.Classes;

namespace BroadcastPluginSDK.Interfaces;

public enum CachePrefixes
{
    DATA,
    COMMAND,
    CONFIG,
    STATUS,
    SYSTEM,
}

public class CacheData
{
    public Dictionary<string,string> Data { get; set; } = new Dictionary<string, string>();
    public CachePrefixes Prefix { get; set; } = CachePrefixes.DATA;
}

public interface ICache
{
    public bool Master { get; set; }
    public List<KeyValuePair<string, string>> CacheReader(List<string> keys);
    public void CacheWriter( CacheData payload);
    public void Clear();
    public IEnumerable<CommandItem> CommandReader(CommandStatus status);
    public void CommandWriter(CommandItem data);
}