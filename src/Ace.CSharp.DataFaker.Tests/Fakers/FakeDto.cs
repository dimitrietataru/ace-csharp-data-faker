using Bogus;

namespace Ace.CSharp.DataFaker.Tests.Fakers;

#pragma warning disable CA1812 // Avoid uninstantiated internal classes

public class FakeDto
{
    private const string LocaleCode = "en_US";

    private static Faker<FooDto> FakeFooDto =>
        new Faker<FooDto>(locale: LocaleCode)
            .RuleFor(
                person => person.Value,
                func => func.Random.Number(1, 100))
            .RuleFor(
                person => person.Description,
                func => func.Lorem.Sentence(wordCount: 10))
        .StrictMode(ensureRulesForAllProperties: true);
}

internal sealed class FooDto
{
    public int Value { get; set; }
    public string Description { get; set; } = default!;
}

internal sealed class BarDto
{
    public Guid Uuid { get; set; }
}
