namespace Supervaga.Domain.Shared.Exceptions
{
    public class UnexpectedException : Exception
    {
        public UnexpectedException(dynamic error, int code, string messade)
        {
            Error = error;
            Code = code;
            Messade = messade;
        }

        public dynamic Error { get; private set; }
        public int Code { get; set; }
        public string Messade { get; set; }
    }
}