using System.Threading.Tasks;

namespace GQL.Core
{
    public interface ICommandHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        Task<TResult> ExecuteAsync();
    }
}
