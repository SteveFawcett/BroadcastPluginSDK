using BroadcastPluginSDK.Classes;

namespace BroadcastPluginSDK.Interfaces;

public interface IProvider
{
    public event EventHandler<CacheData> DataReceived;

    public event EventHandler<CommandItem> CommandReceived;
}