using GQL.AppService.Data;
using GQL.AppService.Domain.Models;
using GQL.AppService.Domain.Queries.Query;
using GQL.AppService.Domain.Queries.Result;
using GQL.Core;
using GQL.Core.DomainContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GQL.AppService.Domain.Queries.Handler
{
    public class GetCaloriesByUserIdHandler : IQueryHandler<GetCaloriesByUserIdQuery, GetCaloriesByUserIdResult>
    {
        private readonly GetCaloriesByUserIdQuery _query;
        private readonly AppDbContext _ctx;
        public GetCaloriesByUserIdHandler(GetCaloriesByUserIdQuery query, AppDbContext ctx)
        {
            _query = query;
            _ctx = ctx;
        }
        public async Task<GetCaloriesByUserIdResult> GetAsync()
        {
            var result = new GetCaloriesByUserIdResult();
            var calories = await _ctx.Calories
                .Where(c => c.UserId == _query.UserId)
                .ToListAsync();

            // TODO : replace with automapper
            foreach (Calorie c in calories)
            {
                var listItem = new CalorieListItem
                {
                    UserId = c.UserId,
                    DateLogged = (c.ModifiedDate != null) ? (DateTime)c.ModifiedDate : c.CreatedDate,
                    Amount = c.Amount
                };
                result.Calories.Add(listItem);
            }

            result.IsSuccess = true;
            return result;
        }
    }
}
