using System.Threading.Tasks;

namespace GQL.Core
{
    public interface IQueryHandler<in TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
        Task<TResponse> GetAsync();
    }
}
