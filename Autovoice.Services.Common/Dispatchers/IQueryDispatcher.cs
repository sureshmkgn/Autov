using System.Threading.Tasks;
using Autovoice.Common.Types;

namespace Autovoice.Common.Dispatchers
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}