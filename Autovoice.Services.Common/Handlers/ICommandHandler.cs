using Autovoice.Common.RabbitMq;
using Autovoice.Common.Messages;
using System.Threading.Tasks;

namespace Autovoice.Common.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, ICorrelationContext context);
    }
}