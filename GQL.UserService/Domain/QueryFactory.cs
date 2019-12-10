using GQL.Core;
using GQL.UserService.Data;
using GQL.UserService.Domain.Queries.Handler;
using GQL.UserService.Domain.Queries.Query;
using GQL.UserService.Domain.Queries.Result;

namespace GQL.UserService.Domain.Queries
{
    public interface IQueryFactory
    {
        IQueryHandler<Query.GetUserQuery, GetUserResult> Build(GetUserQuery query);
    }
    
    public class QueryFactory : IQueryFactory
    {
        private readonly AuthContext _ctx;

        public QueryFactory(AuthContext ctx) 
            => _ctx = ctx;

        public IQueryHandler<Query.GetUserQuery, GetUserResult> Build(Query.GetUserQuery query) 
            => new GetUserHandler(query, _ctx);
    }
}
