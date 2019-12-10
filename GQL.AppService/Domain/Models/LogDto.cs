using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL.AppService.Domain.Models
{
    public abstract class LogDto
    {
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
    }
}
