namespace BroadcastPluginSDK.Interfaces;

public interface ICache
{
    public bool Master { get; set; }
    public List<KeyValuePair<string, string>> CacheReader(List<string> keys);
    public void CacheWriter(Dictionary<string, string> data);
    public void Clear();
    public List<KeyValuePair<string, string>> CommandReader(List<string> keys);
    public void CommandWriter(Dictionary<string, string> data);
}