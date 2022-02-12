namespace Supervaga.Domain.Shared.Consts
{
    public struct RegEx
    {
        public static string JWT = "^[A-Za-z0-9-_=]+\\.[A-Za-z0-9-_=]+\\.?[A-Za-z0-9-_.+/=]*$";
        public static string GUID = "^[0-9A-Fa-f]{8}(?:-[0-9A-Fa-f]{4}){3}-[0-9A-Fa-f]{12}$";

        // summary:
        //     Password should be at least 8 characters, at least one upper, one special char and one number
        public static string STRONG_PASSWORD = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
    }
}