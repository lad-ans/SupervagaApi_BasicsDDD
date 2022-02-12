using Supervaga.Domain.Shared.Contracts.Results;

namespace Supervaga.Domain.Results
{
    public class OkResult<T> : IResult
    {
        public OkResult(bool success, int count, T data)
        {
            Success = success;
            Count = count;
            Data = data;
        }

        public bool Success { get; set; }
        public int Count { get; set; }
        public T? Data { get; set; }

    }

}