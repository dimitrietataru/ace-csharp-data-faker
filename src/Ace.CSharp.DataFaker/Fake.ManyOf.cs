using Ace.CSharp.DataFaker.Internal.Extensions;
using Ace.CSharp.DataFaker.Internal.Symbols;

namespace Ace.CSharp.DataFaker;

public static partial class Fake
{
    /// <summary>
    ///     <para>Generates an instance of <see cref="List{}"/>.</para>
    /// </summary>
    /// <param name="count">The number of items to create</param>
    /// <typeparam name="TResult">The type of the result</typeparam>
    /// <returns>An instance of <see cref="List{}"/></returns>
    public static List<TResult> ManyOf<TResult>(int count = Constants.ManyOfCount)
        where TResult : class
    {
        return new Faker<TResult>().Generate(count);
    }

    /// <summary>
    ///     <para>Generates an instance of <see cref="List{}"/>.</para>
    /// </summary>
    /// <param name="minCount">The min number of items to create</param>
    /// <param name="maxCount">The max number of items to create</param>
    /// <typeparam name="TResult">The type of the result</typeparam>
    /// <returns>An instance of <see cref="List{}"/></returns>
    public static List<TResult> ManyOf<TResult>(int minCount, int maxCount)
        where TResult : class
    {
        return new Faker<TResult>().GenerateBetween(minCount, maxCount);
    }

    /// <summary>
    ///     <para>Generates an instance of <see cref="List{}"/>.</para>
    ///     Uses the configuration defined in the <see cref="{TContainer}"/> class.
    /// </summary>
    /// <param name="count">The number of items to create</param>
    /// <typeparam name="TResult">The type of the result</typeparam>
    /// <typeparam name="TContainer">The type of the lookup class containing the <see cref="Faker{}"/> configuration</typeparam>
    /// <returns>An instance of <see cref="List{}"/></returns>
    /// <exception cref="Exceptions.StaticFakerNotFoundException{TResult}"></exception>
    public static List<TResult> ManyOf<TResult, TContainer>(int count = Constants.ManyOfCount)
        where TResult : class
    {
        return typeof(TContainer).GetFaker<TResult>().Generate(count);
    }

    /// <summary>
    ///     <para>Generates an instance of <see cref="List{}"/>.</para>
    ///     <para>Uses the configuration defined in the <see cref="{TContainer}"/> class.</para>
    /// </summary>
    /// <param name="minCount">The min number of items to create</param>
    /// <param name="maxCount">The max number of items to create</param>
    /// <typeparam name="TResult">The type of the result</typeparam>
    /// <typeparam name="TContainer">The type of the lookup class containing the <see cref="Faker{}"/> configuration</typeparam>
    /// <returns>An instance of <see cref="List{}"/></returns>
    /// <exception cref="Exceptions.StaticFakerNotFoundException{TResult}"></exception>
    public static List<TResult> ManyOf<TResult, TContainer>(int minCount, int maxCount)
        where TResult : class
    {
        return typeof(TContainer).GetFaker<TResult>().GenerateBetween(minCount, maxCount);
    }

    /// <summary>
    ///     <para>Generates an instance of <see cref="List{}"/>.</para>
    ///     <para>Uses the configuration defined in the <see cref="{TContainer}"/> class.</para>
    ///     <para>When configuration is missing, generates an instance using the default implementation of <see cref="Faker{}"/>.</para>
    /// </summary>
    /// <param name="count">The number of items to create</param>
    /// <typeparam name="TResult">The type of the result</typeparam>
    /// <typeparam name="TContainer">The type of the lookup class containing the <see cref="Faker{}"/> configuration</typeparam>
    /// <returns>An instance of <see cref="List{}"/></returns>
    public static List<TResult> ManyOfOrDefault<TResult, TContainer>(int count = Constants.ManyOfCount)
        where TResult : class
    {
        return typeof(TContainer).GetFakerOrDefault<TResult>().Generate(count);
    }

    /// <summary>
    ///     <para>Generates an instance of <see cref="List{}"/>.</para>
    ///     <para>Uses the configuration defined in the <see cref="{TContainer}"/> class.</para>
    ///     <para>When configuration is missing, generates an instance using the default implementation of <see cref="Faker{}"/>.</para>
    /// </summary>
    /// <param name="minCount">The min number of items to create</param>
    /// <param name="maxCount">The max number of items to create</param>
    /// <typeparam name="TResult">The type of the result</typeparam>
    /// <typeparam name="TContainer">The type of the lookup class containing the <see cref="Faker{}"/> configuration</typeparam>
    /// <returns>An instance of <see cref="List{}"/></returns>
    public static List<TResult> ManyOfOrDefault<TResult, TContainer>(int minCount, int maxCount)
        where TResult : class
    {
        return typeof(TContainer).GetFakerOrDefault<TResult>().GenerateBetween(minCount, maxCount);
    }
}
