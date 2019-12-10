using GQL.Core;
using GQL.UserService.Domain.Queries.Result;
using System;

namespace GQL.UserService.Domain.Queries.Query
{
    public class GetUserQuery : IQuery<GetUserResult>
    {
        public Guid Id { get; private set; }
        public GetUserQuery(Guid id) 
            => Id = id;
    }
}
