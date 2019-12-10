using GQL.UserService.Config;
using GQL.UserService.Data;
using GQL.UserService.Domain.Commands;
using GQL.UserService.Domain.Commands.Command;
using GQL.UserService.Domain.Commands.Result;
using GQL.UserService.Domain.Models;
using GQL.UserService.Domain.Queries;
using GQL.UserService.Domain.Queries.Query;
using GQL.UserService.Domain.Queries.Result;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace GQL.UserService.Services
{
    public interface IAuthService
    {
        Task<GetUserResult> GetUserAsync(string id);
        Task<RegisterUserResult> RegisterUserAsync(UserRegistration userRegistration);
        Task<AuthenticateUserResult> AuthenticateUserAsync(UserAuthentication userAuthentication);
    }

    public class AuthService : IAuthService
    {
        private readonly AuthContext _ctx;
        private readonly QueryFactory _queries;
        private readonly CommandFactory _commands;
        public AuthService(AuthContext ctx, IOptions<TokenSettings> settings)
        {
            var secret = settings.Value.Secret;
            _ctx = ctx;
            _queries = new QueryFactory(_ctx);
            _commands = new CommandFactory(_ctx, secret);
        }        

        public async Task<GetUserResult> GetUserAsync(string id)
        {
            Guid guid;
            if (Guid.TryParse(id, out guid))
            {
                var query = new GetUserQuery(guid);
                var handler = _queries.Build(query);
                return await handler.GetAsync();
            }
            else
            {
                return new GetUserResult
                {
                    IsSuccess = false,
                    Message = "Invalid id."
                };
            }
        }

        public async Task<RegisterUserResult> RegisterUserAsync(UserRegistration userRegistration)
        {
            var command = new RegisterUserCommand(userRegistration);
            var handler = _commands.Build(command);
            return await handler.ExecuteAsync();
        }

        public async Task<AuthenticateUserResult> AuthenticateUserAsync(UserAuthentication userAuthentication)
        {
            var command = new AuthenticateUserCommand(userAuthentication);
            var handler = _commands.Build(command);
            return await handler.ExecuteAsync();
        }
    }
}
