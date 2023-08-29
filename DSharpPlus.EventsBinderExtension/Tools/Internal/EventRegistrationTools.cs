using System;
using System.Collections.Generic;
using System.Reflection;
using DSharpPlus.EventsBinderExtension.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.EventsBinderExtension.Tools.Internal;
/*
internal static partial class EventRegistrationTools
{
    public static void RegisterAllHandlers(this IServiceCollection services, Assembly assembly) => services.RegisterAllHandlers(EventsNextUtilities.GetHandlerTypes(assembly));
    public static void RegisterAllHandlers(this IServiceCollection services, IEnumerable<Type> types)
    {
        foreach (Type type in types)
            services.RegisterHandler(type);
    }
    public static void RegisterHandler<THandler>(this IServiceCollection services) where THandler : class, IDiscordEventHandler => services.RegisterHandler(typeof(THandler));
    public static void RegisterHandler(this IServiceCollection services, Type handler)
    {
        EventsNextUtilities.VerifyHandler(handler);
        services.AddScoped(handler);
    }
}
*/