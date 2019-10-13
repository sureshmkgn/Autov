using Autovoice.Common.Handlers;
using Autovoice.Common.Mongo;
using Autovoice.Services.Products.Domain;
using Autovoice.Services.Products.Dto;
using Autovoice.Services.Products.Queries;
using Autovoice.Services.Products.Repositories;
using System.Threading.Tasks;

namespace Autovoice.Services.Products.Handlers
{
    public  class GetProductByNameHandler : IQueryHandler<GetProductByName, ProductDto>
    {
        

        private readonly IMongoRepository<Product> _productRepository;
            
        public GetProductByNameHandler(IMongoRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

       

        public async Task<ProductDto> HandleAsync(GetProductByName query)
        {
             var product = await _productRepository.GetAsync(query.Name);

            return product == null ? null : new ProductDto
            {
                Id = product.Id,
                Name = product.Name
             
            };
        }

      
    }
}
