using System;
using System.Reflection;

namespace DSharpPlus.BetterHosting.CommandsNext.Internal;

internal static class CommandsNextReflector
{
    public static class Utilities
    {
        private static readonly Func<TypeInfo, bool> IsModuleCandidateTypeHandler;
        static Utilities()
        {
            Type utilType = typeof(DSharpPlus.CommandsNext.CommandsNextUtilities);
            IsModuleCandidateTypeHandler = (Func<TypeInfo, bool>)Delegate.CreateDelegate(utilType, utilType.GetMethod("IsModuleCandidateType", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, new Type[] { typeof(TypeInfo) })!);
        }

        public static bool IsModuleCandidateType(Type type)
            => IsModuleCandidateTypeHandler.Invoke(type.GetTypeInfo());

        public static bool IsModuleCandidateType(TypeInfo type)
            => IsModuleCandidateTypeHandler.Invoke(type);
    }
}
