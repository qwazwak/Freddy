using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace FreddyBot.Core.Services.Implementation;

public class ApiNinja : IProfanityDetector, ISentimentAnalyzer, IPasswordGenerator
{
    private const string BaseURL = "https://api.api-ninjas.com/v1/";
    private readonly ILogger<ApiNinja> logger;
    private readonly HttpClient client;

    public ApiNinja(ILogger<ApiNinja> logger, HttpClient client, IConfiguration config)
    {
        this.logger = logger;
        this.client = client;
        string? token = config["ApiNinjaToken"];
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentException("config was missing ApiNinjaToken", nameof(config));
        client.DefaultRequestHeaders.Add("X-Api-Key", token);
    }

    async ValueTask<bool> IProfanityDetector.ContainsProfanity(string text) => (await ContainsProfanity(text)).WasProfane;
    public async Task<(bool WasProfane, string Censored)> ContainsProfanity(string text)
    {

        string requestURL = $"{BaseURL}profanityfilter?text={HttpUtility.UrlEncode(text)}";
        string result = await client.GetStringAsync(requestURL);
        try
        {
            JObject oResult = JObject.Parse(result);

            return (Convert.ToBoolean(oResult["has_profanity"]?.ToString()), oResult["censored"]?.ToString() ?? string.Empty);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "unable to parse result {json}", result);
            throw;
        }
    }

    async Task<double> ISentimentAnalyzer.AnalyzeSentiment(string text) => (await AnalyzeSentiment(text)).Score;
    public async Task<(double Score, string Sentiment)> AnalyzeSentiment(string text)
    {

        string requestURL = $"{BaseURL}sentiment?text={HttpUtility.UrlEncode(text)}";
        string result = await client.GetStringAsync(requestURL);
        try
        {
            JObject oResult = JObject.Parse(result);

            return (double.Parse(oResult["score"]!.ToString()), oResult["sentiment"]!.ToString());
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "unable to parse result {json}", result);
            throw;
        }
    }
    public async ValueTask<string> GeneratePassword(int length, bool includeNumbers, bool includeSpecialChars)
    {
        string requestURL = $"{BaseURL}passwordgenerator?length={length}&exclude_numbers={!includeNumbers}&exclude_special_chars={!includeSpecialChars}";
        string result = default!;
        try
        {
            result = await client.GetStringAsync(requestURL);
            JObject oResult = JObject.Parse(result);

            return oResult["random_password"]!.ToString();
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "unable to parse result {json}", result);
            throw;
        }
    }
    public enum Sentiment
    {
        Negative,
        Neutral,
        Positive,
    }
}