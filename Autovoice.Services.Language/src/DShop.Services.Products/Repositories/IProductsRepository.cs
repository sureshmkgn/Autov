using Autovoice.Common.Types;
using Autovoice.Services.Products.Domain;
using Autovoice.Services.Products.Queries;
using System;
using System.Threading.Tasks;

namespace Autovoice.Services.Products.Repositories
{
    public interface IProductsRepository
    {
        Task<Product> GetAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<bool> ExistsAsync(string name);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid id);
    }
}