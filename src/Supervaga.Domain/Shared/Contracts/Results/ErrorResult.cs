namespace Supervaga.Domain.Shared.Contracts.Results
{
    public class ErrorResult : IResult
    {
        public ErrorResult(bool success, string error)
        {
            Success = success;
            Error = error;
        }

        public bool Success { get; set; }
        public string Error { get; set; }
    }
}