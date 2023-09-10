using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using FreddyBot.Core.Data.Tables.KeyBases;
using FreddyBot.Core.Data.Tables.Interfaces;

namespace FreddyBot.Core.Data.Tables;

[Table(TableName)]
[PrimaryKey(nameof(ColumnNames.GuildID), nameof(PollKeyed.ColumnNames.PollID))]
public class Poll : PollKeyed, IDBTable
{
    public const string TableName = "Polls";
    static string IDBTable.TableName => TableName;
    public new class ColumnNames : PollKeyed.ColumnNames
    {
        public new const string GuildID = PollKeyed.ColumnNames.GuildID;
        public const string PollTitle = "PollTitle";
    }

    [Column(ColumnNames.PollTitle)]
    public string PollTitle { get; set; } = default!;

    public List<PollChoice> PollChoices { get; set; } = default!;
}
