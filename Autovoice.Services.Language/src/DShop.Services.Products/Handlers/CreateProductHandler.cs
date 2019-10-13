using Autovoice.Common.Handlers;
using Autovoice.Common.RabbitMq;
using Autovoice.Services.Products.Messages.Commands;
using Autovoice.Services.Products.Messages.Events;
using Autovoice.Services.Products.Domain;
using Autovoice.Services.Products.Repositories;
using System.Threading.Tasks;
using Autovoice.Common.Types;

namespace Autovoice.Services.Products.Handlers
{
    public sealed class CreateProductHandler : ICommandHandler<CreateProduct>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IBusPublisher _busPublisher;

        public CreateProductHandler(
            IProductsRepository productsRepository,
            IBusPublisher busPublisher)
        {
            _productsRepository = productsRepository;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(CreateProduct command, ICorrelationContext context)
        {
            if (await _productsRepository.ExistsAsync(command.Name))
            {
                throw new DShopException("product_already_exists",
                    $"Product: '{command.Name}' already exists.");
            }

            var product = new Product(command.Id, command.Name);
            await _productsRepository.AddAsync(product);
            await _busPublisher.PublishAsync(new ProductCreated(command.Id, command.Name) ,context);
        }
    }
}
