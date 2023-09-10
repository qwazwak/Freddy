using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FreddyBot.Core.Data.Tables.KeyBases;
using FreddyBot.Core.Data.Tables.Interfaces;

namespace FreddyBot.Core.Data.Tables;

[Table(TableName)]
[PrimaryKey(nameof(ColumnNames.GuildID), nameof(PollKeyed.ColumnNames.PollID), nameof(ColumnNames.ChoiceID))]
public class PollChoice : PollKeyed, IDBTable
{
    public const string TableName = "SwearJars";
    static string IDBTable.TableName => TableName;
    public new class ColumnNames : PollKeyed.ColumnNames
    {
        public new const string GuildID = GuildKeyed.ColumnNames.GuildID;
        public const string ChoiceID = "ID";
        public const string Text = "Text";
        public const string Icon = "Icon";
    }

    [Column(ColumnNames.ChoiceID)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ChoiceID { get; set; }

    [Column(ColumnNames.Text)]
    public string Text { get; set; } = default!;

    [Column(ColumnNames.Icon)]
    public string Icon { get; set; } = default!;

    public Poll Poll { get; set; } = default!;
}