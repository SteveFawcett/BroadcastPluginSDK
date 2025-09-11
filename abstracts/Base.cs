﻿using BroadcastPluginSDK.Classes;
using BroadcastPluginSDK.Interfaces;
using BroadcastPluginSDK.Properties;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Reflection;
namespace BroadcastPluginSDK.abstracts;

public abstract class BroadcastPluginBase : IPlugin
{
    private IConfiguration _configuration;
    private Image? _icon;
    private IInfoPage? _infoPage;
    private MainIcon _mainIcon;
    private string? _stanza;
    private static Image DefaultImage => Resources.red;
    // New protected constructor for DI
    protected BroadcastPluginBase(
        IConfiguration? configuration = null,
        IInfoPage? infoPage = null,
        Image? icon = null,
        string? stanza = null )
    {
        _icon = icon ?? DefaultImage;
        _stanza = stanza;
        _mainIcon = new MainIcon(this, _icon);
        _infoPage = infoPage ?? new InfoPage
        {
            Icon = _icon,
            Name = GetType().FullName ?? GetType().Name,
            Version = DerivedAssembly.GetName().Version?.ToString() ?? "NOT SET",
        };

        if (!string.IsNullOrEmpty(stanza) && configuration != null)
        {
            var section = configuration.GetSection(stanza);
            _configuration = section.Exists() ? section : new ConfigurationBuilder().AddInMemoryCollection().Build();
        }
        else
        {
            _configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
        }
    }

    public virtual Image Icon
    {
        get => _icon ?? Resources.red;
        set => _icon = value;
    }

    public Assembly DerivedAssembly => GetType().Assembly;
    public string? Stanza => _stanza;
    public string Name => GetType().FullName ?? GetType().Name;
    public string Version => DerivedAssembly.GetName().Version?.ToString() ?? "NOT SET";
    public string Description => GetAssemblyMetadata("Description") ?? "No description available.";
    public string ShortName => (GetType().FullName ?? GetType().Name).Split('.').First();

    public bool Enabled
    {
        get => _configuration.GetValue("Enabled", true);
    }
    public MainIcon MainIcon
    {
        get => _mainIcon;
        set
        {
            _mainIcon = value;
            _mainIcon.Click += (s, e) => OnClick( e );
            _mainIcon.MouseHover += (s, e) => OnHover();
        }
    }

    public IInfoPage InfoPage
    {
        get => _infoPage ?? new InfoPage();
        set => _infoPage = value as InfoPage;
    }

    public virtual GetCacheDataDelegate? GetCacheData { set; get; } = null;
    public string FilePath { get; set; } = string.Empty;
    public string RepositoryUrl => GetAssemblyMetadata("RepositoryUrl") ?? string.Empty;

    public event EventHandler<MouseEventArgs>? Click;
    public event EventHandler? MouseHover;
    public event EventHandler<Image>? ImageChanged;

    private string? GetAssemblyMetadata(string key)
    {
        return DerivedAssembly
            .GetCustomAttributes<AssemblyMetadataAttribute>()
            .FirstOrDefault(attr => attr.Key == key)
            ?.Value;
    }

    public static void DumpConfiguration(IConfiguration config, string indent = "")
    {
        foreach (var section in config.GetChildren())
        {
            var value = section.Value;
            var key = section.Path;

            Debug.WriteLine($"{indent}{key} = {value}");

            // Recurse into children
            DumpConfiguration(section, indent + "  ");
        }
    }

    public void ImageChangedInvoke(Image img)
    {
        ImageChanged?.Invoke(this, img);
    }

    internal void OnClick(EventArgs e)
    {
        var args = e as MouseEventArgs ?? new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
        Click?.Invoke(this, args);
    }

    internal void OnHover()
    {
        MouseHover?.Invoke(this, EventArgs.Empty);
    }
}
