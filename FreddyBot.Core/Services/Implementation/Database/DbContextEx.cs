using FreddyBot.Core.Services.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FreddyBot.Core.Services.Implementation.Database;

public abstract class DbContextEx : DbContext
{
    private readonly string DbPath;

    protected DbContextEx(string DbPath) => this.DbPath = DbPath;
    protected DbContextEx(IOptions<FileProviderOptions> options) : this(options.Value.DBFilePath) { }

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
}