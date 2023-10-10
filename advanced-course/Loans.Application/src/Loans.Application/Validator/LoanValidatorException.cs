public class LoanValidationException : Exception
{
    public LoanValidationException(string? message) : base(message)
    {
    }

    public LoanValidationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}