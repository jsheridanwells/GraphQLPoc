using GQL.AppService.Data;
using GQL.AppService.Domain.Queries.Handler;
using GQL.AppService.Domain.Queries.Query;
using GQL.AppService.Domain.Queries.Result;
using GQL.Core.DomainContracts;

namespace GQL.AppService.Domain.Queries
{
    public interface IQueryFactory
    {
        IQueryHandler<GetWeightsByUserIdQuery, GetWeightsByUserIdResult> Build(GetWeightsByUserIdQuery query);
        IQueryHandler<GetCaloriesByUserIdQuery, GetCaloriesByUserIdResult> Build(GetCaloriesByUserIdQuery query);
    }

    public class QueryFactory : IQueryFactory
    {
        private readonly AppDbContext _ctx;

        public QueryFactory(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryHandler<GetWeightsByUserIdQuery, GetWeightsByUserIdResult> Build(GetWeightsByUserIdQuery query)
            => new GetWeightByUserIdHandler(query, _ctx);

        public IQueryHandler<GetCaloriesByUserIdQuery, GetCaloriesByUserIdResult> Build(GetCaloriesByUserIdQuery query)
            => new GetCaloriesByUserIdHandler(query, _ctx);
    }
}
