using GQL.Core;
using GQL.UserService.Data;
using GQL.UserService.Domain.Queries.Query;
using GQL.UserService.Domain.Queries.Result;
using System;
using System.Threading.Tasks;

namespace GQL.UserService.Domain.Queries.Handler
{
    public class GetUserHandler : IQueryHandler<Query.GetUserQuery, GetUserResult>
    {
        private readonly Query.GetUserQuery _query;
        private readonly AuthContext _ctx;

        public GetUserHandler(Query.GetUserQuery query, AuthContext ctx)
        {
            _query = query;
            _ctx = ctx;
        }
        public async Task<GetUserResult> GetAsync()
        {
            var result = new GetUserResult { IsSuccess = false };
            try
            {
                var user = await _ctx.Users.FindAsync(_query.Id);
                if (user != null)
                {
                    // TODO : add automapper
                    result.IsSuccess = true;
                    result.User.Name = user.Name;
                    result.User.Email = user.Email;
                    result.User.Id = user.Id;
                    return result;
                }
                else
                {
                    result.User = null;
                    result.Message = "User not found.";
                    return result;
                }
            }
            catch (Exception e)
            {
                result.Message = "Error retrieving user.";
                return result;
            }
        }
    }
}
