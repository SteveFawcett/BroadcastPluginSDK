using BroadcastPluginSDK.Classes;
using BroadcastPluginSDK.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace BroadcastPluginSDK.abstracts;

public abstract class BroadcastCacheBase : BroadcastPluginBase, ICache
{
    protected BroadcastCacheBase(
        IConfiguration? configuration = null,
        IInfoPage? infoPage = null,
        Image? icon = null,
        string? stanza = null) : base(configuration, infoPage, icon, stanza)
    {
        if (configuration != null)
        {
            Debug.WriteLine("Configuration");
            var config = configuration.GetSection(stanza ?? "Cache").GetChildren();
            var masterSection = config.FirstOrDefault(section => section.Key == "master");
            bool.TryParse(masterSection?.Value, out bool master);
            Master = master;
        }
        else
        {
            Master = false;
        }
    }
    public bool Master { get; set; }
    public abstract void CacheWriter(CacheData payload );
    public abstract void Clear();
    public abstract void CommandWriter(CommandItem data);
}