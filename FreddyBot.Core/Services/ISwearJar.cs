using System.Threading.Tasks;

namespace FreddyBot.Core.Services;

public interface ISwearJar
{
    Task<decimal> GetSwearCount();
    Task SetSingleSwearValue(decimal value);
    Task<decimal> GetSingleSwearValue();
    Task<decimal> GetCurrentValue();
    Task AddSwear();
}
