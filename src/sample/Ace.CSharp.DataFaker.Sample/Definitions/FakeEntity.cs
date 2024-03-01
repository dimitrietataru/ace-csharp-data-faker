using Ace.CSharp.DataFaker.Sample.Definitions.Entities;

namespace Ace.CSharp.DataFaker.Sample.Definitions;

public sealed class FakeEntity
{
    private const string LocaleCode = "en_US";
    private const int DefaultCount = 3;
    private static readonly DateTime refDate = new(2000, 01, 01);

    public static T Of<T>()
        where T : class
    {
        return Fake.Of<T, FakeEntity>();
    }

    public static List<T> ManyOf<T>(int count = DefaultCount)
        where T : class
    {
        return Fake.ManyOf<T, FakeEntity>(count);
    }

    public static List<T> ManyOf<T>(int minCount, int maxCount)
        where T : class
    {
        return Fake.ManyOf<T, FakeEntity>(minCount, maxCount);
    }

    private static Faker<Foo> FakeFoo =>
        new Faker<Foo>(locale: LocaleCode)
            .RuleFor(
                dto => dto.Id,
                func => func.Random.Uuid())
            .RuleFor(
                dto => dto.Title,
                func => func.Lorem.Sentence())
            .RuleFor(
                dto => dto.Description,
                func => func.Lorem.Sentences())
            .RuleFor(
                dto => dto.AvatarUrl,
                func => func.Internet.Avatar())
            .RuleFor(
                dto => dto.Index,
                func => func.Random.Int(min: 1, max: int.MaxValue))
            .RuleFor(
                dto => dto.Size,
                func => func.Random.Decimal(min: 1.0M, max: 10.0M))
            .RuleFor(
                dto => dto.CreatedAt,
                func => func.Date.PastOffset(yearsToGoBack: 1, refDate))
            .RuleFor(
                dto => dto.ExpiresAt,
                func => func.Date.FutureOffset(yearsToGoForward: 1, refDate))
            .RuleFor(
                dto => dto.IsActive,
                func => func.Random.Bool())
            .StrictMode(ensureRulesForAllProperties: true);
}
