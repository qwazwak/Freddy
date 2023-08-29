using System.Threading;
using System.Threading.Tasks;

namespace FreddyBot.Core.Services;

public interface ISystemSetup
{
    public Task Run(CancellationToken cancellationToken);
}