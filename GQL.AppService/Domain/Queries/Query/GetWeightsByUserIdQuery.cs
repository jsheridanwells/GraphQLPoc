using GQL.AppService.Domain.Queries.Result;
using GQL.Core;
using GQL.Core.DomainContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL.AppService.Domain.Queries.Query
{
    public class GetWeightsByUserIdQuery : IQuery<GetWeightsByUserIdResult>
    {
        public Guid UserId { get; private set; }

        public GetWeightsByUserIdQuery(Guid userId)
            => UserId = userId;
    }
}
