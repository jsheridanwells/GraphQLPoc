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
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, RegisterUserResult>
    {
        private readonly RegisterUserCommand _cmd;
        private readonly AuthContext _ctx;
        public RegisterUserCommandHandler(RegisterUserCommand cmd, AuthContext ctx)
        {
            _cmd = cmd;
            _ctx = ctx;
        }
        public async Task<RegisterUserResult> ExecuteAsync()
        {
            var result = new RegisterUserResult();
            
            // 1. Is the email already registered?
            try
            {
                var checkUser = await _ctx.Users.FirstOrDefaultAsync(
                    u => u.Email == _cmd.UserRegistration.Email    
                );
                if (checkUser != null)
                {
                    result.Message = $"A user with an email address of { _cmd.UserRegistration.Email } already exists.";
                    return result;
                }
            }
            catch (Exception)
            {

                result.Message = "Error registering new user";
                return result;
            }

            // 2. Create hashed passwords
            byte[] hash, salt;
            try
            {
                PasswordManager.EncryptPassword(_cmd.UserRegistration.Password, out hash, out salt);
            }
            catch (Exception)
            {

                result.Message = "Error registering new user";
                return result;
            }

            // 3. Save the new user
            try
            {
                var user = new UserEntity
                {
                    Name = _cmd.UserRegistration.Name,
                    Email = _cmd.UserRegistration.Email,
                    PasswordHash = hash,
                    PasswordSalt = salt
                };
                await _ctx.Users.AddAsync(user);
                await _ctx.SaveChangesAsync();
                result.UserId = user.Id;
                result.IsSuccess = true;
                return result;
            }
            catch (Exception)
            {
                result.Message = "Error registering new user";
                return result;
            }
        }
    }
}
