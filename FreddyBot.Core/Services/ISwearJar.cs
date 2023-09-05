using System.Threading.Tasks;

namespace FreddyBot.Core.Services;

public interface ISwearJar
{
    Task<decimal> GetSwearCount(ulong guildID);
    Task SetSingleSwearValue(ulong guildID, decimal value);
    Task<decimal> GetSingleSwearValue(ulong guildID);
    Task<decimal> GetCurrentValue(ulong guildID);
    Task IncrementJar(ulong guildID);
}
