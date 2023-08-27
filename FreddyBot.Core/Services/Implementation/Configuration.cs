using System.Collections.Generic;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace FreddyBot.Core.Services.Implementation;

public class Configuration : IConfiguration, IConfigurationRoot
{
    private static readonly Lazy<Configuration> autoInstance = new(() =>
    {
        IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
        return new(builder.Build());
    });

    public static Configuration AutoInstance => autoInstance.Value;

    private readonly IConfigurationRoot root;
    public Configuration(IConfigurationRoot root) => this.root = root;

    public string? this[string key] { get => root[key]; set => root[key] = value; }

    public IEnumerable<IConfigurationProvider> Providers => root.Providers;

    public IEnumerable<IConfigurationSection> GetChildren() => root.GetChildren();
    public IChangeToken GetReloadToken() => root.GetReloadToken();
    public IConfigurationSection GetSection(string key) => root.GetSection(key);
    public void Reload() => root.Reload();
}
