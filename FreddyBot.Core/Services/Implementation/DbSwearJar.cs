#if DBSwear
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

    public async Task<decimal> GetSwearCount() => (await Jar).SwearCount;

    public async Task SetSingleSwearValue(decimal value)
    {
        SwearJar jar = await Jar;
        if (jar.ValueOfSingleSwear != value)
        {
            logger.LogInformation("Replacing swear value of {old} with {new}", jar.ValueOfSingleSwear, value);
            jar.ValueOfSingleSwear = value;
            await db.SaveChangesAsync();
        }
    }

    public async Task AddSwear()
    {
        SwearJar jar = await Jar;
        jar.SwearCount += 1;
        await db.SaveChangesAsync();
    }

    public async Task<decimal> GetSingleSwearValue() => (await Jar).ValueOfSingleSwear;
    public async Task<decimal> GetCurrentValue() => (await Jar).CurrentJarValue;

    private Task<SwearJar> Jar => ReadJar();
    private async Task<SwearJar> ReadJar()
    {
        try
        {

            var result = await db.SwearJars.SingleAsync();
            return result;
        }
        catch (Exception ex)
        {
            SwearJar newJar = new();
            db.SwearJars.Add(newJar);
            return newJar;
            Console.WriteLine(ex.Message);
        }
    }
}
#endif