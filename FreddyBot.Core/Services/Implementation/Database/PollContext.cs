using FreddyBot.Core.Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace FreddyBot.Core.Services.Implementation.Database;

public class PollContext : DbContextEx
{
    public DbSet<Poll> Polls { get; set; }
    public DbSet<PollChoice> Choices { get; set; }

    public PollContext(FileProvider provider) : base(provider) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
