using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FreddyBot.Core.Data.Tables.KeyBases;

public abstract class PollKeyed : GuildKeyed
{
    public new class ColumnNames : GuildKeyed.ColumnNames
    {
        public new const string GuildID = GuildKeyed.ColumnNames.GuildID;
        public const string PollID = "PollID";
    }

    [Column(ColumnNames.PollID)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid PollID { get; set; }
}
