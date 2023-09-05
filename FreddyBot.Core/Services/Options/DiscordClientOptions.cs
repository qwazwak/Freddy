using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FreddyBot.Core.Services.Options;

public class DiscordClientOptions : IOptions<DiscordClientOptions>, IValidatableObject
{
    [Required(AllowEmptyStrings = false)]
    [ConfigurationKeyName("DISCORD_TOKEN_FREDDY")]
    public string DiscordToken { get; set; } = default!;

    DiscordClientOptions IOptions<DiscordClientOptions>.Value => this;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(DiscordToken))
            yield return new($"Error! Discord token (key: {DiscordToken ?? "null"}) was not found!");
    }
}
