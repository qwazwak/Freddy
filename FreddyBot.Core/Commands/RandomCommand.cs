using DSharpPlus.CommandsNext;
using System.Threading.Tasks;
using System;
using DSharpPlus.SlashCommands;

namespace FreddyBot.Core.Commands;

public sealed class RandomSlashCommand : ApplicationCommandModule
{
    private readonly Random random;

    public RandomSlashCommand(Random random) => this.random = random;

    [SlashCommand("random", "Returns a random number within the specified range. Defaults between 0 and 10.")]

    public async Task RandomAsync(CommandContext context, int min = 0, int max = 10, bool maxIsInclusive = true)
    {
        // Ensure that the minimum value is less than or equal to the maximum value.
        if (min > max)
        {
            // Inform the user that they messed up.
            await context.RespondAsync("The minimum value must be less than or equal to the maximum value.");
            return;
        }
        if(maxIsInclusive)
            max += 1;
        // Respond with the random number.
        await context.RespondAsync($"Your random number is {random.Next(min, max)}.");
    }
}
