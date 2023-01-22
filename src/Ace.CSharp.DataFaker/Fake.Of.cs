using Ace.CSharp.DataFaker.Internal.Extensions;

namespace Ace.CSharp.DataFaker;

public static partial class Fake
{
    /// <summary>
    ///     <para>Generates an instance of <see cref="{TResult}"/>.</para>
    /// </summary>
    /// <typeparam name="TResult">The type of the result</typeparam>
    /// <returns>An instance of <see cref="{TResult}"/></returns>
    public static TResult Of<TResult>()
        where TResult : class
    {
        return new Faker<TResult>().Generate();
    }

    /// <summary>
    ///     <para>Generates an instance of <see cref="{TResult}"/>.</para>
    ///     <para>Uses the configuration defined in the <see cref="{TContainer}"/> class.</para>
    /// </summary>
    /// <typeparam name="TResult">The type of the result</typeparam>
    /// <typeparam name="TContainer">The type of the lookup class containing the <see cref="Faker{T}"/> configuration</typeparam>
    /// <returns>An instance of <see cref="{TResult}"/></returns>
    /// <exception cref="Exceptions.FakerNotFoundException{TResult}"></exception>
    public static TResult Of<TResult, TContainer>()
        where TResult : class
    {
        return typeof(TContainer).GetFaker<TResult>().Generate();
    }

    /// <summary>
    ///     <para>Generates an instance of <see cref="{TResult}"/>.</para>
    ///     <para>Uses the configuration defined in the <see cref="{TContainer}"/> class.</para>
    ///     <para>When configuration is missing, generates an instance using the default implementation of <see cref="Faker{T}"/>.</para>
    /// </summary>
    /// <typeparam name="TResult">The type of the result</typeparam>
    /// <typeparam name="TContainer">The type of the lookup class containing the <see cref="Faker{T}"/> configuration</typeparam>
    /// <returns>An instance of <see cref="{TResult}"/></returns>
    public static TResult OfOrDefault<TResult, TContainer>()
        where TResult : class
    {
        return typeof(TContainer).GetFakerOrDefault<TResult>().Generate();
    }
}
