using Bogus;

namespace Ace.CSharp.DataFaker.Tests.Fakers;

public sealed class FakeEntity : AbstractDataFaker<FakeEntity>
{
    private Faker<FooEntity> FakeFooEntity =>
        new Faker<FooEntity>(locale: LocaleCode)
            .RuleFor(
                person => person.Value,
                func => func.Random.Number(1, 100))
            .RuleFor(
                person => person.Description,
                func => func.Lorem.Sentence(wordCount: 10))
            .StrictMode(ensureRulesForAllProperties: true);
}

internal sealed class FooEntity
{
    public int Value { get; set; }
    public string Description { get; set; } = default!;
}

internal sealed class BarEntity
{
    public Guid Uuid { get; set; }
}
