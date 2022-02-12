namespace Supervaga.Domain.Shared.Contracts.Results
{
    public class ValidationErrorsResult : IResult
    {
        public ValidationErrorsResult()
        {
            Success = false;
            Error = "Ocorreu um erro de validação";
        }

        public bool Success { get; set; }
        public string Error { get; set; }
    }
}