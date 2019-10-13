using System.Threading.Tasks;
using Autovoice.Common.Types;
using Autovoice.Common.Messages;

namespace Autovoice.Common.Dispatchers
{
    public interface IDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}