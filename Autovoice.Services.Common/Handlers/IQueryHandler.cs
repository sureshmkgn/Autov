using System.Threading.Tasks;
using Autovoice.Common.Types;

namespace Autovoice.Common.Handlers
{
    public interface IQueryHandler<TQuery,TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}