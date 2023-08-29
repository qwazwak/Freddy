using System.Threading.Tasks;

namespace FreddyBot.Core.Services;

public interface IPasswordGenerator
{
    public ValueTask<string> GeneratePassword(int length, bool includeNumbers, bool includeSpecialChars);
}
