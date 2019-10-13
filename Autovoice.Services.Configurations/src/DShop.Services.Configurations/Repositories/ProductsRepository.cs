using System;
using System.Threading.Tasks;
using Autovoice.Common.Mongo;
using Autovoice.Common.Types;
using Autovoice.Services.Configurations.Domain;


namespace Autovoice.Services.Configurations.Repositories
{
    public class ConfigurationsRepository : IConfigurationsRepository
    {
        private readonly IMongoRepository<Configuration> _repository;

        public ConfigurationsRepository(IMongoRepository<Configuration> repository)
        {
            _repository = repository;
        }

        public Task<Configuration> GetAsync(Guid id)
            =>  _repository.GetAsync(id);

        public async Task<bool> ExistsAsync(Guid id)
            => await _repository.ExistsAsync(p => p.Id == id);

        public async Task<bool> ExistsAsync(string name)
            => await _repository.ExistsAsync(p => p.Name == name.ToLowerInvariant());

        public async Task AddAsync(Configuration product)
            => await _repository.AddAsync(product);

        public async Task UpdateAsync(Configuration product)
            => await _repository.UpdateAsync(product);

        public async Task DeleteAsync(Guid id)
            => await _repository.DeleteAsync(id);
    }
}