using System.Collections.Generic;
using System.Threading.Tasks;
using Autovoice.Common.Dispatchers;
using Autovoice.Common.Types;
using Autovoice.Services.Products.Dto;
using Autovoice.Services.Products.Messages.Commands;
using Autovoice.Services.Products.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Autovoice.Services.Products.Controllers
{
    [Route("[controller]")]
    public class ProductsController : BaseController
    {
        private readonly IDispatcher _dispatcher;
        public ProductsController(IDispatcher dispatcher)
            :base(dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductDto>> GetAsync([FromRoute] GetProduct query)
        {
            var product = await _dispatcher.QueryAsync(query);
            if (product is null)
            {
                return NotFound();
            }

            return product;

        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ProductDto>> GetAsync([FromRoute] GetProductByName query)
        {
            var product = await _dispatcher.QueryAsync(query);
            if (product is null)
            {
                return NotFound();
            }

            return product;

        }


        [HttpPost]
        public async Task<ActionResult> Post(CreateProduct command)
        {
            await _dispatcher.SendAsync(command);
            return Accepted();
        }
    }
}
