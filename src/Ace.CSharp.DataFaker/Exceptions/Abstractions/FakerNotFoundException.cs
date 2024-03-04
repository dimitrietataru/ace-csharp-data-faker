namespace Ace.CSharp.DataFaker.Exceptions.Abstractions;

public abstract class FakerNotFoundException<TResult> : Exception
{
    protected FakerNotFoundException()
        : base()
    {
    }

    protected FakerNotFoundException(string message)
        : base(message)
    {
    }

    protected FakerNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
