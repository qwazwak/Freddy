using System.Threading.Tasks;

namespace FreddyBot.Core.Services;

public interface ISentimentAnalyzer
{
    public Task<double> AnalyzeSentiment(string text);
}
