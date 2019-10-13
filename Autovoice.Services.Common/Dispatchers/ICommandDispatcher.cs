using System.Threading.Tasks;
using Autovoice.Common.Messages;

namespace Autovoice.Common.Dispatchers
{
    public interface ICommandDispatcher
    {
         Task SendAsync<T>(T command) where T : ICommand;
    }
}