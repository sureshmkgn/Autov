using Autovoice.Common.Handlers;
using Autovoice.Common.Mongo;
using Autovoice.Services.Configurations.Domain;
using Autovoice.Services.Configurations.Dto;
using Autovoice.Services.Products.Queries;

using System.Threading.Tasks;

namespace Autovoice.Services.Configurations.Handlers
{
    public  class GetConfigurationByKeyHandler : IQueryHandler<GetConfigurationByKey, ConfigurationDto>
    {
        

        private readonly IMongoRepository<Configuration> _configurationRepository;
            
        public GetConfigurationByKeyHandler(IMongoRepository<Configuration> configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

       

        public async Task<ConfigurationDto> HandleAsync(GetConfigurationByKey query)
        {
             var Configuration = await _configurationRepository.GetAsync(query.Key);

            return Configuration == null ? null : new ConfigurationDto
            {
                Id = Configuration.Id,
                Key = Configuration.Name,
                Value = Configuration.Value

            };
        }

      
    }
}
