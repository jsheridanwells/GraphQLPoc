using System;

namespace GQL.AppService.Data
{
    public class Weight
    {
        
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? Active { get; set; } = true;
        public decimal Amount { get; set; }
        public WeightUnit WeightUnit { get; set; } = WeightUnit.Lbs;
    }
}
