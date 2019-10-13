using System.Threading.Tasks;

namespace Autovoice.Common.Mongo
{
    public interface IMongoDbSeeder
    {
        Task SeedAsync();
    }
}