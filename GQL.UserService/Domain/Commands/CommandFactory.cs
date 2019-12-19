using GQL.Core;
using GQL.Core.DomainContracts;
using GQL.UserService.Data;
using GQL.UserService.Domain.Commands.Command;
using GQL.UserService.Domain.Commands.Handler;
using GQL.UserService.Domain.Commands.Result;

namespace GQL.UserService.Domain.Commands
{
    public interface ICommandFactory
    {
        ICommandHandler<RegisterUserCommand, RegisterUserResult> Build(RegisterUserCommand cmd);
        ICommandHandler<AuthenticateUserCommand, AuthenticateUserResult> Build(AuthenticateUserCommand cmd);
    }

    public class CommandFactory : ICommandFactory
    {
        private readonly AuthContext _ctx;
        private readonly string _secret;

        public CommandFactory(AuthContext ctx, string secret)
        {
            _ctx = ctx;
            _secret = secret;
        }

        public ICommandHandler<RegisterUserCommand, RegisterUserResult> Build(RegisterUserCommand cmd)
            => new RegisterUserCommandHandler(cmd, _ctx);

        public ICommandHandler<AuthenticateUserCommand, AuthenticateUserResult> Build(AuthenticateUserCommand cmd)
            => new AuthenticateUserCommandHandler(cmd, _ctx, _secret);
    }
}
