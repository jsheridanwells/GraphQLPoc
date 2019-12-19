using System.Threading.Tasks;

namespace GQL.Core.DomainContracts
{
    public interface IQueryHandler<in TQuery, TResponse>
        where TResponse : ResultBase where TQuery : IQuery<TResponse>
    {
        Task<TResponse> GetAsync();
    }
}
