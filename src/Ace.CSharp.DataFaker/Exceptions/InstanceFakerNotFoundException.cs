using Ace.CSharp.DataFaker.Exceptions.Abstractions;

namespace Ace.CSharp.DataFaker.Exceptions;

public sealed class InstanceFakerNotFoundException<TResult, TContainer> : FakerNotFoundException<TResult>
{
    public InstanceFakerNotFoundException()
        : base($"Fake<{nameof(TResult)}> not found on {nameof(TContainer)}")
    {
    }

    public InstanceFakerNotFoundException(string message)
        : base(message)
    {
    }

    public InstanceFakerNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
