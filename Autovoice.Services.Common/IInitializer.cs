using System.Threading.Tasks;

namespace Autovoice.Common
{
    public interface IInitializer
    {
        Task InitializeAsync();
    }
}