using GQL.AppService.Domain.Models;
using GQL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL.AppService.Domain.Queries.Result
{
    public class GetCaloriesByUserIdResult : ResultBase
    {
        public List<CalorieListItem> Calories { get; private set; }
        public GetCaloriesByUserIdResult()
        {
            Calories = new List<CalorieListItem>();
        }
    }
}
