namespace TaskManagerCleanArchitecture.Application.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException(string message) : base("The provided credentials are invalid.")
        { }
    }
}