using Supervaga.Domain.Shared.Contracts.Commands;
using Supervaga.Domain.Shared.Contracts.Results;

namespace Domain.Shared.Contracts.Handlers
{
    public interface IHandler<T> where T : Command
    {
        Task<IResult> Handle(T command, object? data = null);
    }
}