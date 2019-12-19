using GQL.Core;
using GQL.Core.DomainContracts;
using GQL.UserService.Domain.Models;

namespace GQL.UserService.Domain.Commands.Result
{
    public class AuthenticateUserResult : ResultBase
    {
        public User User { get; set; }
        public string Token { get; set; }
        public AuthenticateUserResult() 
            => this.User = new User();
    }
}
