using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL.AppService.Data
{
    public class Calorie
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? Active { get; set; } = true;
        public int Amount { get; set; }
    }
}
