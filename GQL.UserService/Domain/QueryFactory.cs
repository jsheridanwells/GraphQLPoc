using GQL.Core;
using GQL.Core.DomainContracts;
using GQL.UserService.Data;
using GQL.UserService.Domain.Queries.Handler;
using GQL.UserService.Domain.Queries.Query;
using GQL.UserService.Domain.Queries.Result;

namespace GQL.UserService.Domain.Queries
{
    public interface IQueryFactory
    {
        IQueryHandler<GetUserQuery, GetUserResult> Build(GetUserQuery query);
        IQueryHandler<GetApiKeyQuery, GetApiKeyResult> Build(GetApiKeyQuery query);
    }
    
    public class QueryFactory : IQueryFactory
    {
        private readonly AuthContext _ctx;

        public QueryFactory(AuthContext ctx) 
            => _ctx = ctx;

        public IQueryHandler<Query.GetUserQuery, GetUserResult> Build(Query.GetUserQuery query) 
            => new GetUserHandler(query, _ctx);

        public IQueryHandler<GetApiKeyQuery, GetApiKeyResult> Build(GetApiKeyQuery query)
            => new GetApiKeyHandler(query, _ctx);   
    }
}
