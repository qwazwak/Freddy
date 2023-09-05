using FreddyBot.Core.Data.Tables;
using FreddyBot.Core.Services.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FreddyBot.Core.Services.Implementation.Database;

public class SwearJarContext : DbContextEx
{
    public DbSet<SwearJar> SwearJars { get; set; }

    public SwearJarContext(IOptions<FileProviderOptions> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}