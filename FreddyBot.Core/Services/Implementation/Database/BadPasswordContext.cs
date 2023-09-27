using FreddyBot.Core.Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace FreddyBot.Core.Services.Implementation.Database;

public class BadPasswordContext : DbContext
{
    public DbSet<BadPassword> BadPasswords { get; set; }
}