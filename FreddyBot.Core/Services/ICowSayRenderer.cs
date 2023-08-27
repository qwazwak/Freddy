using System.Threading.Tasks;

namespace FreddyBot.Core.Services;

public interface ICowSayRenderer
{
    public ValueTask<string> Render(string cow, string phrase, string? eyes, string? cowTongue, int? maxCols, bool? isThought);
}
