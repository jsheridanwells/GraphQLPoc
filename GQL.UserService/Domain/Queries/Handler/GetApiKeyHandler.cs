using GQL.Core;
using GQL.Core.DomainContracts;
using GQL.UserService.Data;
using GQL.UserService.Domain.Queries.Query;
using GQL.UserService.Domain.Queries.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL.UserService.Domain.Queries.Handler
{
    public class GetApiKeyHandler : IQueryHandler<GetApiKeyQuery, GetApiKeyResult>
    {
        private readonly GetApiKeyQuery _query;
        private readonly AuthContext _ctx;

        public GetApiKeyHandler(GetApiKeyQuery query, AuthContext ctx)
        {
            _query = query;
            _ctx = ctx;
        }
        public async Task<GetApiKeyResult> GetAsync()
        {
            var result = new GetApiKeyResult();
            var keyEntry 
                = await _ctx.ApiKeys.FirstOrDefaultAsync(x => x.Key == _query.ApiKey);
            result.ApiKey = keyEntry.Key ?? null;
            result.IsSuccess = true;
            return result;
        }
    }
}
