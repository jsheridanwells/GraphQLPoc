using GQL.AppService.Domain.Commands.Result;
using GQL.AppService.Domain.Models;
using GQL.Core;
using GQL.Core.DomainContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL.AppService.Domain.Commands.Command
{
    public class LogCalorieCommand : ICommand<LogCalorieResult>
    {
        public LogCalorieDto Data { get; private set; }
        public LogCalorieCommand(LogCalorieDto dto) 
            => Data = dto;
    }
}
