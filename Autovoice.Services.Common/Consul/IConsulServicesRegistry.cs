using System.Threading.Tasks;
using Consul;

namespace Autovoice.Common.Consul
{
    public interface IConsulServicesRegistry
    {
        Task<AgentService> GetAsync(string name);
    }
}