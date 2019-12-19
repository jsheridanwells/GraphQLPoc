using GQL.AppService.Data;
using GQL.AppService.Domain.Commands.Command;
using GQL.AppService.Domain.Commands.Handler;
using GQL.AppService.Domain.Commands.Result;
using GQL.Core;
using GQL.Core.DomainContracts;
using System.Threading.Tasks;

namespace GQL.AppService.Domain.Commands.Handler
{
    public class LogWeightHandler : ICommandHandler<LogWeightCommand, LogWeightResult>
    {
        private readonly LogWeightCommand _cmd;
        private readonly AppDbContext _ctx;

        public LogWeightHandler(LogWeightCommand cmd, AppDbContext ctx)
        {
            _cmd = cmd;
            _ctx = ctx;
        }
        public async Task<LogWeightResult> ExecuteAsync()
        {
            // TODO : Exception handling
            var result = new LogWeightResult();
            // TODO : add automapper
            var log = new Weight
            {
                UserId = _cmd.Data.UserId,
                Amount = _cmd.Data.Amount,
                WeightUnit = _cmd.Data.WeightUnit
            };

            _ctx.Weights.Add(log);
            await _ctx.SaveChangesAsync();
            result.IsSuccess = true;
            return result;
        }
    }
}
