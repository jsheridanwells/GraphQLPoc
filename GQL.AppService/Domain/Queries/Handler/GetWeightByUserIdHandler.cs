using GQL.AppService.Data;
using GQL.AppService.Domain.Models;
using GQL.AppService.Domain.Queries.Query;
using GQL.AppService.Domain.Queries.Result;
using GQL.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GQL.AppService.Domain.Queries.Handler
{
    public class GetWeightByUserIdHandler : IQueryHandler<GetWeightsByUserIdQuery, GetWeightsByUserIdResult>
    {
        private readonly GetWeightsByUserIdQuery _query;
        private readonly AppDbContext _ctx;

        public GetWeightByUserIdHandler(GetWeightsByUserIdQuery query, AppDbContext ctx)
        {
            _query = query;
            _ctx = ctx;
        }

        public async Task<GetWeightsByUserIdResult> GetAsync()
        {
            var result = new GetWeightsByUserIdResult();

            var weights = await _ctx.Weights
                .Where(w => w.UserId == _query.UserId)
                .ToListAsync();

            // TODO : replace with automapper
            foreach (Weight w in weights)
            {
                var listItem = new WeightListItem
                {
                    UserId = w.UserId,
                    DateLogged = (w.ModifiedDate != null) ? (DateTime)w.ModifiedDate : w.CreatedDate,
                    Amount = w.Amount,
                    Unit = w.WeightUnit.ToString()
                };
                result.Weights.Add(listItem);
            }
            result.IsSuccess = true;
            return result;
        }
    }
}
