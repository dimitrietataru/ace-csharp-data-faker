namespace Ace.CSharp.DataFaker.Exceptions;

public sealed class FakerNotFoundException<TResult> : Exception
{
    public FakerNotFoundException()
        : base($"Fake<{nameof(TResult)}> not found")
    {
    }

    public FakerNotFoundException(string message)
        : base(message)
    {
    }

    public FakerNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
