namespace ProductManagementSystem.Application.Exceptions;

public class ApplicationException : Exception
{
    public ApplicationException(string message, int statusCode, bool isConfidentiality) : base(message)
    {
        StatusCode = statusCode;
        IsConfidentiality = isConfidentiality;
    }

    public int StatusCode { get; private set; }
    public bool IsConfidentiality { get; private set; }
}