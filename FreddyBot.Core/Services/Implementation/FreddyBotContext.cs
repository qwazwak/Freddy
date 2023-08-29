using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FreddyBot.Core.Services.Implementation;

public class FreddyBotContext : DbContext
{
    public DbSet<SwearJar> SwearJars { get; set; }

    public async Task<SwearJar> GetOrCreateJar(ulong guildID)
    {
        SwearJar? jar = await SwearJars.FindAsync(guildID);
        if (jar != null)
            return jar;

        SwearJar newJar = new() { GuildID = guildID };
        SwearJars.Add(newJar);
        await SaveChangesAsync();
        return newJar;
    }

    private readonly string DbPath;

    public FreddyBotContext(IOptions<FileProviderOptions> options) => DbPath = options.Value.DBFilePath;

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}

[Table("SwearJars")]
public class SwearJar
{
    [Key]
    [Column("GuildID")]
    public ulong GuildID { get; set; }

//    [DefaultValue("0.25")]
    [Column("ValueOfSingleSwear")]
    public decimal ValueOfSingleSwear { get; set; } = 0.25m;

    [Column("SwearCount")]
    public int SwearCount { get; set; } = 1;

    [NotMapped]
    public decimal CurrentJarValue => ValueOfSingleSwear * SwearCount;
}
