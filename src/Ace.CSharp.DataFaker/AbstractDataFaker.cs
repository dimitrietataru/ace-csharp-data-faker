using Ace.CSharp.DataFaker.Internal.Resources;
using Ace.CSharp.DataFaker.Internal.Symbols;
using TypeExt = Ace.CSharp.DataFaker.Internal.Extensions.TypeExtensions;

namespace Ace.CSharp.DataFaker;

#pragma warning disable CA1716 // Identifiers should not match keywords

public interface IDataFaker
{
    Faker<T> GetFaker<T>() where T : class;

    T Of<T>() where T : class;
    T OfOrDefault<T>() where T : class;

    List<T> ManyOf<T>(int count = Constants.ManyOfCount) where T : class;
    List<T> ManyOf<T>(int minCount, int maxCount) where T : class;

    List<T> ManyOfOrDefault<T>(int count = Constants.ManyOfCount) where T : class;
    List<T> ManyOfOrDefault<T>(int minCount, int maxCount) where T : class;
}

public abstract class AbstractDataFaker<TContainer> : IDataFaker
    where TContainer : class, IDataFaker, new()
{
    protected virtual string LocaleCode { get; } = DataFakerOptionsResources.DefaultLocaleCode;
    protected virtual int DefaultCount { get; } = DataFakerOptionsResources.DefaultCollectionCount;
    protected virtual DateTime RefDate { get; } = new(2000, 01, 01);

    public Faker<TResult> GetFaker<TResult>()
        where TResult : class
    {
        return TypeExt.GetFaker<TResult, TContainer>();
    }

    public TResult Of<TResult>()
        where TResult : class
    {
        return TypeExt.GetFaker<TResult, TContainer>().Generate();
    }

    public TResult OfOrDefault<TResult>()
        where TResult : class
    {
        return TypeExt.GetFakerOrDefault<TResult, TContainer>().Generate();
    }

    public List<TResult> ManyOf<TResult>(int count = Constants.ManyOfCount)
        where TResult : class
    {
        return TypeExt.GetFaker<TResult, TContainer>().Generate(count);
    }

    public List<TResult> ManyOf<TResult>(int minCount, int maxCount)
        where TResult : class
    {
        return TypeExt.GetFaker<TResult, TContainer>().GenerateBetween(minCount, maxCount);
    }

    public List<TResult> ManyOfOrDefault<TResult>(int count = Constants.ManyOfCount)
        where TResult : class
    {
        return TypeExt.GetFakerOrDefault<TResult, TContainer>().Generate(count);
    }

    public List<TResult> ManyOfOrDefault<TResult>(int minCount, int maxCount)
        where TResult : class
    {
        return TypeExt.GetFakerOrDefault<TResult, TContainer>().GenerateBetween(minCount, maxCount);
    }
}
