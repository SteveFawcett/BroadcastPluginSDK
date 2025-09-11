using BroadcastPluginSDK.Classes;

namespace BroadcastPluginSDK.Interfaces;

public interface ICache
{
    public bool Master { get; set; }
    public List<KeyValuePair<string, string>> CacheReader(List<string> keys);
    public void CacheWriter(Dictionary<string, string> data);
    public void Clear();
    public IEnumerable<CommandItem> CommandReader(BroadcastPluginSDK.Classes.CommandStatus status);
    public void CommandWriter(CommandItem data);
}