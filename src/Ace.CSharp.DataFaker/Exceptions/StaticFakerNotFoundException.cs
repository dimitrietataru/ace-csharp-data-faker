using Ace.CSharp.DataFaker.Exceptions.Abstractions;

namespace Ace.CSharp.DataFaker.Exceptions;

public sealed class StaticFakerNotFoundException<TResult> : FakerNotFoundException<TResult>
{
    public StaticFakerNotFoundException()
        : base($"Fake<{nameof(TResult)}> not found")
    {
    }

    public StaticFakerNotFoundException(string message)
        : base(message)
    {
    }

    public StaticFakerNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
