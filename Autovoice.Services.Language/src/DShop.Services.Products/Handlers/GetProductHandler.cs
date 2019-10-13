using Autovoice.Common.Handlers;
using Autovoice.Common.Mongo;
using Autovoice.Services.Products.Domain;
using Autovoice.Services.Products.Dto;
using Autovoice.Services.Products.Queries;
using Autovoice.Services.Products.Repositories;
using System.Threading.Tasks;

namespace Autovoice.Services.Products.Handlers
{
    public  class GetProductHandler : IQueryHandler<GetProduct, ProductDto>
    {
        

        private readonly IMongoRepository<Product> _productRepository;

        public GetProductHandler(IMongoRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

       

        public async Task<ProductDto> HandleAsync(GetProduct query)
        {
            //var discounts = await _productRepository.FindAsync(
            //    p => p.Id == query.Id);

           

            //var product = await _productRepository.GetAsync(query.Id);

            var product = await _productRepository.GetAsync(query.Id);

            return product == null ? null : new ProductDto
            {
                Id = product.Id,
                Name = product.Name
             
            };
        }
    }
}
