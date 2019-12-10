using GQL.Core;
using GQL.UserService.Domain.Commands.Result;
using GQL.UserService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL.UserService.Domain.Commands.Command
{
    public class RegisterUserCommand : ICommand<RegisterUserResult>
    {
        public UserRegistration UserRegistration { get; private set; }
        public RegisterUserCommand(UserRegistration userRegistration) 
            => this.UserRegistration = userRegistration;
    }
}
