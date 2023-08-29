using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace FreddyBot.Core.Services.Implementation;
public class DbSwearJar : ISwearJar
{
    private readonly ILogger<DbSwearJar> logger;
    private readonly FreddyBotContext db;

    public DbSwearJar(ILogger<DbSwearJar> logger, FreddyBotContext db)
    {
        this.logger = logger;
        this.db = db;
    }

    public async Task<decimal> GetSwearCount(ulong guildID) => (await GetJar(guildID)).SwearCount;

    public async Task SetSingleSwearValue(ulong guildID, decimal value)
    {
        SwearJar jar = await GetJar(guildID);
        if (jar.ValueOfSingleSwear != value)
        {
            logger.LogInformation("Replacing swear value of {old} with {new}", jar.ValueOfSingleSwear, value);
            jar.ValueOfSingleSwear = value;
            await db.SaveChangesAsync();
        }
    }

    public async Task AddSwear(ulong guildID)
    {
        try
        {

            SwearJar jar = await GetJar(guildID);
            jar.SwearCount += 1;
            await db.SaveChangesAsync();
        }
        catch (System.Exception ex)
        {
            logger.LogWarning(ex, "broke");
        }
    }

    public async Task<decimal> GetSingleSwearValue(ulong guildID) => (await GetJar(guildID)).ValueOfSingleSwear;
    public async Task<decimal> GetCurrentValue(ulong guildID) => (await GetJar(guildID)).CurrentJarValue;

    private async Task<SwearJar> GetJar(ulong guildID)
    {
        return await db.GetOrCreateJar(guildID);
    }
}
