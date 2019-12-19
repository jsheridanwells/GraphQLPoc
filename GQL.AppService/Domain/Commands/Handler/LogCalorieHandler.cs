using GQL.AppService.Data;
using GQL.AppService.Domain.Commands.Command;
using GQL.AppService.Domain.Commands.Result;
using GQL.Core;
using GQL.Core.DomainContracts;
using System.Threading.Tasks;

namespace GQL.AppService.Domain.Commands.Handler
{
    public class LogCalorieHandler : ICommandHandler<LogCalorieCommand, LogCalorieResult>
    {
        private readonly LogCalorieCommand _cmd;
        private readonly AppDbContext _ctx;
        public LogCalorieHandler(LogCalorieCommand cmd, AppDbContext ctx)
        {
            _cmd = cmd;
            _ctx = ctx;
        }
        public async Task<LogCalorieResult> ExecuteAsync()
        {
            // TODO : Exception handling
            var result = new LogCalorieResult();
            // TODO : add automapper
            var log = new Calorie
            {
                UserId = _cmd.Data.UserId,
                Amount = (int)_cmd.Data.Amount
            };

            _ctx.Calories.Add(log);
            await _ctx.SaveChangesAsync();
            result.IsSuccess = true;
            return result;
        }
    }
}
