using GQL.AppService.Data;
using System;

namespace GQL.AppService.Domain.Models
{
    public class LogWeightDto : LogDto
    {        
        public WeightUnit WeightUnit { get; set; } = WeightUnit.Lbs;
    }
}
