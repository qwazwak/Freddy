using System;
using System.Threading.Tasks;
using FreddyBot.Core.Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace FreddyBot.Core.Services.Implementation.Database;

public class BadPasswordContext : DbContext
{
    public DbSet<BadPassword> BadPasswords { get; set; }


    internal Task FindAsync(int iD) => throw new NotImplementedException();
}