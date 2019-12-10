using System;

namespace GQL.AppService.Domain.Models
{
    public abstract class ListItem
    {
        public Guid UserId { get; set; }
        public DateTime DateLogged { get; set; }
        public decimal Amount { get; set; }
    }
}
