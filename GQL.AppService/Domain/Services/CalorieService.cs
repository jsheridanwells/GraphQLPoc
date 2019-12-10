using GQL.AppService.Domain.Commands;
using GQL.AppService.Domain.Commands.Command;
using GQL.AppService.Domain.Commands.Result;
using GQL.AppService.Domain.Models;
using GQL.AppService.Domain.Queries;
using GQL.AppService.Domain.Queries.Query;
using GQL.AppService.Domain.Queries.Result;
using System;
using System.Threading.Tasks;

namespace GQL.AppService.Domain.Services
{
    public interface ICalorieService
    {
        Task<GetCaloriesByUserIdResult> GetCaloriesByUserId(string userId);
        Task<LogCalorieResult> LogCalorie(LogCalorieDto logDto);
    }

    public class CalorieService : ICalorieService
    {
        private readonly IQueryFactory _queries;
        private readonly ICommandFactory _commands;
        public CalorieService(IQueryFactory queries, ICommandFactory commands)
        {
            _queries = queries;
            _commands = commands;
        }
        public async Task<GetCaloriesByUserIdResult> GetCaloriesByUserId(string userId)
        {
            Guid guid;
            if (Guid.TryParse(userId, out guid))
            {
                var query = new GetCaloriesByUserIdQuery(guid);
                var handler = _queries.Build(query);
                return await handler.GetAsync();
            }
            else
            {
                throw new ArgumentException("Invalid user ID.");
            }
        }

        public async Task<LogCalorieResult> LogCalorie(LogCalorieDto logDto)
        {
            var command = new LogCalorieCommand(logDto);
            var handler = _commands.Build(command);
            return await handler.ExecuteAsync();
        }
    }
}
