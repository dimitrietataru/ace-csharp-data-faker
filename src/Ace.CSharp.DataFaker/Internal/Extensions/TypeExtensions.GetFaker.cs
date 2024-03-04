using Ace.CSharp.DataFaker.Exceptions;

namespace Ace.CSharp.DataFaker.Internal.Extensions;

internal static partial class TypeExtensions
{
    public static Faker<TResult> GetFaker<TResult>(this Type @this)
        where TResult : class
    {
        return @this.GetFakerPropertyValue<TResult>()
            ?? throw new StaticFakerNotFoundException<TResult>();
    }

    public static Faker<TResult> GetFaker<TResult, TContainer>()
        where TResult : class
        where TContainer : class, new()
    {
        return GetFakerPropertyValue<TResult, TContainer>()
            ?? throw new InstanceFakerNotFoundException<TResult, TContainer>();
    }

    public static Faker<TResult> GetFakerOrDefault<TResult>(this Type @this)
        where TResult : class
    {
        return @this.GetFakerPropertyValue<TResult>()
            ?? new Faker<TResult>();
    }

    public static Faker<TResult> GetFakerOrDefault<TResult, TContainer>()
        where TResult : class
        where TContainer : class, new()
    {
        return GetFakerPropertyValue<TResult, TContainer>()
            ?? new Faker<TResult>();
    }
}
