using GQL.Core;
using GQL.Core.DomainContracts;
using GQL.UserService.Domain.Queries.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL.UserService.Domain.Queries.Query
{
    public class GetApiKeyQuery : IQuery<GetApiKeyResult>
    {
        public string ApiKey { get; private set; }
        public GetApiKeyQuery(string key)
            => ApiKey = key;
    }
}
