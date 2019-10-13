using System.Collections.Generic;
using System.Threading.Tasks;
using Autovoice.Common.Dispatchers;
using Autovoice.Common.Types;
using Autovoice.Services.Configurations.Dto;
using Autovoice.Services.Configurations.Messages.Commands;
using Autovoice.Services.Configurations.Queries;
using Autovoice.Services.Products.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Autovoice.Services.Products.Controllers
{
    [Route("[controller]")]
    public class ConfigController : BaseController
    {
        private readonly IDispatcher _dispatcher;
        public ConfigController(IDispatcher dispatcher)
            :base(dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ConfigurationDto>> GetAsync([FromRoute] GetConfiguration query)
        {
            var product = await _dispatcher.QueryAsync(query);
            if (product is null)
            {
                return NotFound();
            }

            return product;

        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ConfigurationDto>> GetAsync([FromRoute] GetConfigurationByKey query)
        {
            var product = await _dispatcher.QueryAsync(query);
            if (product is null)
            {
                return NotFound();
            }

            return product;

        }


        [HttpPost]
        public async Task<ActionResult> Post(CreateConfiguration command)
        {
            await _dispatcher.SendAsync(command);
            return Accepted();
        }
    }
}
