using Autovoice.Common.Handlers;
using Autovoice.Common.RabbitMq;
using Autovoice.Common.Types;
using Autovoice.Services.Configurations.Messages.Commands;
using Autovoice.Services.Configurations.Messages.Events;
using Autovoice.Services.Configurations.Repositories;



using System.Threading.Tasks;

namespace Autovoice.Services.Configurations.Handlers
{
    public sealed class DeleteConfigurationtHandler : ICommandHandler<DeleteConfiguration>
    {
        private readonly IConfigurationsRepository _ConfigurationRepository;
        private readonly IBusPublisher _busPublisher;

        public DeleteConfigurationtHandler(
            IConfigurationsRepository configurationRepository,
            IBusPublisher busPublisher)
        {
            _ConfigurationRepository = configurationRepository;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(DeleteConfiguration command, ICorrelationContext context)
        {
            if (!await _ConfigurationRepository.ExistsAsync(command.Id))
            {
                throw new DShopException("product_not_found",
                    $"Product with id: '{command.Id}' was not found.");
            }

            await _ConfigurationRepository.DeleteAsync(command.Id);
            await _busPublisher.PublishAsync(new ConfigurationDeleted(command.Id), context);
        }
    }
}
