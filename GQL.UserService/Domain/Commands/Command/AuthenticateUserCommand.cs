using GQL.Core;
using GQL.Core.DomainContracts;
using GQL.UserService.Domain.Commands.Result;
using GQL.UserService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL.UserService.Domain.Commands.Command
{
    public class AuthenticateUserCommand : ICommand<AuthenticateUserResult>
    {
        public UserAuthentication UserAuthentication { get; private set; }
        public AuthenticateUserCommand(UserAuthentication userAuth)
            => UserAuthentication = userAuth;
    }
}
