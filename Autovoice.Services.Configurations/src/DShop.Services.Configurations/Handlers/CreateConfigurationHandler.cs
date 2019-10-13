using Autovoice.Common.Handlers;
using Autovoice.Common.RabbitMq;
using System.Threading.Tasks;
using Autovoice.Common.Types;
using Autovoice.Services.Configurations.Messages.Commands;
using Autovoice.Services.Configurations.Repositories;
using Autovoice.Services.Configurations.Messages.Events;
using Autovoice.Services.Configurations.Domain;

namespace Autovoice.Services.Configurations.Handlers
{
    public sealed class CreateConfigurationHandler : ICommandHandler<CreateConfiguration>
    {
        private readonly IConfigurationsRepository _configurationRepository;
        private readonly IBusPublisher _busPublisher;

        public CreateConfigurationHandler(
            IConfigurationsRepository productsRepository,
            IBusPublisher busPublisher)
        {
            _configurationRepository = productsRepository;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(CreateConfiguration command, ICorrelationContext context)
        {
            if (await _configurationRepository.ExistsAsync(command.Name))
            {
                throw new DShopException("product_already_exists",
                    $"Product: '{command.Name}' already exists.");
            }

            var configuration = new Configuration(command.Id, command.Name,command.Value);
            await _configurationRepository.AddAsync(configuration);
            await _busPublisher.PublishAsync(new ConfigurationCreated(command.Id, command.Name) ,context);
        }
    }
}
