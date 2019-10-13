using Autovoice.Common.Handlers;
using Autovoice.Common.Mongo;
using Autovoice.Services.Configurations.Domain;
using Autovoice.Services.Configurations.Dto;
using Autovoice.Services.Configurations.Queries;
using System.Threading.Tasks;

namespace Autovoice.Services.Configurations.Handlers
{
    public  class GetConfigurationHandler : IQueryHandler<GetConfiguration, ConfigurationDto>
    {
        

        private readonly IMongoRepository<Configuration> _configurationRepository;

        public GetConfigurationHandler(IMongoRepository<Configuration> configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

       

        public async Task<ConfigurationDto> HandleAsync(GetConfiguration query)
        {
            var configuration = await _configurationRepository.GetAsync(query.Id);

            return configuration == null ? null : new ConfigurationDto
            {
                Id = configuration.Id,
                Key = configuration.Name,
                Value =configuration.Value 
             
            };
        }
    }
}
