using GQL.Core;
using GQL.Core.DomainContracts;
using System;

namespace GQL.UserService.Domain.Commands.Result
{
    public class RegisterUserResult : ResultBase
    {
        public Guid UserId { get; set; }
    }
}
