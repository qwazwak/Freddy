using FreddyBot.Core.Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace FreddyBot.Core.Services.Implementation.Database;

public class SwearJarContext : DbContext
{
    public DbSet<SwearJar> SwearJars { get; set; }
}