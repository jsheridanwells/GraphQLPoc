using GQL.AppService.Domain.Queries.Result;
using GQL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL.AppService.Domain.Queries.Query
{
    public class GetCaloriesByUserIdQuery : IQuery<GetCaloriesByUserIdResult>
    {
        public Guid UserId { get; private set; }
        public GetCaloriesByUserIdQuery(Guid userId) 
            => UserId = userId;
    }
}
