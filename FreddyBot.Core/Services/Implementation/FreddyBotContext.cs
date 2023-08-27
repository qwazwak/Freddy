#if DB
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FreddyBot.Core.Services.Implementation;

public class FreddyBotContext : DbContext
{
    public DbSet<SwearJar> SwearJars { get; set; }

    private readonly string DbPath;

    public FreddyBotContext()
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        string path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "FreddyBot.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class SwearJar
{
    [Key]
    public Guid GuildID { get; set; }

    [DefaultValue("0.25")]
    public decimal ValueOfSingleSwear { get; set; }

    [DefaultValue(0)]
    public decimal SwearCount { get; set; }

    [NotMapped]
    public decimal CurrentJarValue => ValueOfSingleSwear * SwearCount;
}
#endif