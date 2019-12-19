using GQL.AppService.Data;
using GQL.AppService.Domain.Commands.Command;
using GQL.AppService.Domain.Commands.Handler;
using GQL.AppService.Domain.Commands.Result;
using GQL.Core;
using GQL.Core.DomainContracts;

namespace GQL.AppService.Domain.Commands
{
    public interface ICommandFactory
    {
        public ICommandHandler<LogWeightCommand, LogWeightResult> Build(LogWeightCommand cmd);
        public ICommandHandler<LogCalorieCommand, LogCalorieResult> Build(LogCalorieCommand cmd);

    }
    public class CommandFactory : ICommandFactory
    {
        private readonly AppDbContext _ctx;
        public CommandFactory(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public ICommandHandler<LogWeightCommand, LogWeightResult> Build(LogWeightCommand cmd)
            => new LogWeightHandler(cmd, _ctx);

        public ICommandHandler<LogCalorieCommand, LogCalorieResult> Build(LogCalorieCommand cmd)
            => new LogCalorieHandler(cmd, _ctx);
    }
}
