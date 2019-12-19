using GQL.Core;
using GQL.Core.DomainContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL.UserService.Domain.Queries.Result
{
    public class GetApiKeyResult : ResultBase
    {
        public string ApiKey { get; set; }
    }
}
