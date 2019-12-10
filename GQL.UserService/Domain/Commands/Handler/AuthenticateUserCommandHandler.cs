using GQL.Core;
using GQL.UserService.Data;
using GQL.UserService.Domain.Commands.Command;
using GQL.UserService.Domain.Commands.Result;
using GQL.UserService.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GQL.UserService.Domain.Commands.Handler
{
    public class AuthenticateUserCommandHandler : ICommandHandler<AuthenticateUserCommand, AuthenticateUserResult>
    {
        private readonly AuthenticateUserCommand _cmd;
        private readonly AuthContext _ctx;
        private readonly string _secret;
        public AuthenticateUserCommandHandler(AuthenticateUserCommand cmd, AuthContext ctx, string secret)
        {
            _cmd = cmd;
            _ctx = ctx;
            _secret = secret;
        }

        public async Task<AuthenticateUserResult> ExecuteAsync()
        {
            var result = new AuthenticateUserResult { IsSuccess = false };
            UserEntity userEntity;

            // 1. find the user by email
            try
            {
                userEntity = await _ctx.Users
                    .FirstOrDefaultAsync(u => u.Email == _cmd.UserAuthentication.Email);

                if (userEntity == null)
                {
                    result.Message 
                        = $"A user with email { _cmd.UserAuthentication.Email } could not be found.";
                    result.IsSuccess = false;
                    return result;
                }
            }
            catch (Exception e)
            {
                // TODO : some sort of exception logging
                result.IsSuccess = false;
                result.Message = "There was an error retrieving the user.";
                return result;
            }

            // 2. verify the password
            var authenticated = PasswordManager.VerifyPassword(
                _cmd.UserAuthentication.Password,
                userEntity.PasswordHash,
                userEntity.PasswordSalt
            );

            // 3. if valid, return user info with auth token
            if (authenticated)
            {
                // TODO : add automapper
                result.User.Id = userEntity.Id;
                result.User.Name = userEntity.Name;
                result.User.Email = userEntity.Email;
                result.Token = TokenManager.GenerateToken(userEntity.Id, _secret); // TODO : pass in secret
                result.IsSuccess = true;
                return result;
            }

            // 4. if invalid, reject the request
            else
            {
                result.Message = "Invalid password.";
                result.IsSuccess = false;
                return result;
            }
        }
    }
}
