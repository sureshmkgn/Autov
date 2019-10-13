using Autovoice.Common.RabbitMq;
using Autovoice.Common.Messages;
using System.Threading.Tasks;

namespace Autovoice.Common.Handlers
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event, ICorrelationContext context);
    }
}