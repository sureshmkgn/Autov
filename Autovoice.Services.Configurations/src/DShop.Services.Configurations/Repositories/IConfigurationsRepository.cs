using Autovoice.Common.Types;
using Autovoice.Services.Configurations.Domain;

using System;
using System.Threading.Tasks;

namespace Autovoice.Services.Configurations.Repositories
{
    public interface IConfigurationsRepository
    {
        Task<Configuration> GetAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<bool> ExistsAsync(string name);
        Task AddAsync(Configuration product);
        Task UpdateAsync(Configuration product);
        Task DeleteAsync(Guid id);
    }
}