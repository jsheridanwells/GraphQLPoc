using GQL.Core;
using GQL.UserService.Domain.Models;

namespace GQL.UserService.Domain.Queries.Result
{
    public class GetUserResult : ResultBase
    {
        public User User { get; set; }
        public GetUserResult() 
            => User = new User();
    }
}
