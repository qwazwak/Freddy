using System;
using System.Threading.Tasks;
using FreddyBot.Core.Data.Tables;
using FreddyBot.Core.Services.Implementation.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace FreddyBot.Core.Services.Implementation;
public class BadPasswordGenerator : IPasswordGenerator
{
    private readonly BadPasswordContext context;
    private readonly BadPasswordCounter counter;
    private readonly Random rng;

    public BadPasswordGenerator(BadPasswordContext context, BadPasswordCounter counter, Random rng)
    {
        this.context = context;
        this.counter = counter;
        this.rng = rng;
    }

    ValueTask<string> IPasswordGenerator.GeneratePassword(int length, bool includeNumbers, bool includeSpecialChars) => new(GeneratePassword(CancellationToken.None));
    public async Task<string> GeneratePassword(CancellationToken cancellationToken)
    {
        BadPassword? result;
        do
        {
            int count = await counter.Count;
            if (count == 0)
                throw new InvalidOperationException("No passwords to give!");

            int index = rng.Next(count);

            result = await context.BadPasswords.Skip(index).FirstOrDefaultAsync(cancellationToken);
        } while (result == null);

        return result.Password;
    }
}