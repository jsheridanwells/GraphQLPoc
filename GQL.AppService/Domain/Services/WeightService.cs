using GQL.AppService.Data;
using GQL.AppService.Domain.Commands;
using GQL.AppService.Domain.Commands.Command;
using GQL.AppService.Domain.Commands.Result;
using GQL.AppService.Domain.Models;
using GQL.AppService.Domain.Queries;
using GQL.AppService.Domain.Queries.Query;
using GQL.AppService.Domain.Queries.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL.AppService.Domain.Services
{
    public interface IWeightService
    {
        Task<GetWeightsByUserIdResult> GetWeightsByUserId(string userId);   
        Task<LogWeightResult> LogWeight(LogWeightDto logDto);
    }

    public class WeightService : IWeightService
    {
        private readonly IQueryFactory _queries;
        private readonly ICommandFactory _commands;

        public WeightService(IQueryFactory queries, ICommandFactory commands)
        {
            _queries = queries;
            _commands = commands;
        }
        public async Task<GetWeightsByUserIdResult> GetWeightsByUserId(string userId)
        {
            Guid guid; 
            if (Guid.TryParse(userId, out guid))
            {
                var query = new GetWeightsByUserIdQuery(guid);
                var handler = _queries.Build(query);
                return await handler.GetAsync();
            }
            else
            {
                throw new ArgumentException("Invalid user ID.");
            }
        }

        public async Task<LogWeightResult> LogWeight(LogWeightDto logDto)
        {
            var command = new LogWeightCommand(logDto);
            var handler = _commands.Build(command);
            return await handler.ExecuteAsync();
        }
    }
}
