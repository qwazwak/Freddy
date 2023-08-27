using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace FreddyBot.Discord;

public static partial class EventBinder
{
    public static void AddAllHandlers(this IServiceCollection services) => AddAllHandlers(services, Assembly.GetExecutingAssembly());
    public static void AddAllHandlers(this IServiceCollection services, Assembly assembly)
    {
        IEnumerable<Type> types = assembly.GetTypes().Where(t => typeof(IDiscordEventHandler).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);
        AddAllHandlers(services, types);
    }
    public static void AddAllHandlers(this IServiceCollection services, IEnumerable<Type> types)
    {

        foreach (Type type in types)
        {
            if (typeof(IDiscordEventHandler).IsAssignableTo(type))
                throw new ArgumentException($"Type {type.Name} is not a {nameof(IDiscordEventHandler)}");

            services.AddScoped(type);
        }
    }
}