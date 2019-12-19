using GQL.AppService.Domain.Models;
using GQL.Core;
using GQL.Core.DomainContracts;
using System.Collections.Generic;

namespace GQL.AppService.Domain.Queries.Result
{

    public class GetWeightsByUserIdResult : ResultBase
    {
        public List<WeightListItem> Weights { get; set; }
        public GetWeightsByUserIdResult() 
            => Weights = new List<WeightListItem>();
    }
}
