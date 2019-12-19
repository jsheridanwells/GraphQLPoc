using GQL.AppService.Domain.Commands.Result;
using GQL.AppService.Domain.Models;
using GQL.Core;
using GQL.Core.DomainContracts;

namespace GQL.AppService.Domain.Commands.Command
{
    public class LogWeightCommand : ICommand<LogWeightResult>
    {
        public LogWeightDto Data { get; private set; }
        public LogWeightCommand(LogWeightDto data) 
            => this.Data = data;
    }
}
