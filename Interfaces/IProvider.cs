namespace BroadcastPluginSDK.Interfaces;

public interface IProvider
{
    public event EventHandler<CacheData> DataReceived;
}