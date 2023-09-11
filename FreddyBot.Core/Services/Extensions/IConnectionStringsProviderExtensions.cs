using System;

namespace FreddyBot.Core.Services.Extensions;

public static class IConnectionStringsProviderExtensions
{
    public const string DefaultConnectionName = "Default";

    public static string Default(this IConnectionStringsProvider provider) => provider.GetRequired(DefaultConnectionName);
    public static string GetRequired(this IConnectionStringsProvider provider, string? name) => provider.Get(name ?? DefaultConnectionName) ?? throw new ArgumentException($"Connection string \"{name}\" is required, but was not found");
}
