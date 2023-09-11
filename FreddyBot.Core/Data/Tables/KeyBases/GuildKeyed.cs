using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FreddyBot.Core.Data.Tables.KeyBases;

public abstract class GuildKeyed
{
    public class ColumnNames
    {
        public const string GuildID = "GuildID";
    }

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column(ColumnNames.GuildID)]
    public ulong GuildID { get; set; }
}