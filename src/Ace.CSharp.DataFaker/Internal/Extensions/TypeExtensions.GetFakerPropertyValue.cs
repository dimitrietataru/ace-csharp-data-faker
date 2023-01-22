namespace Ace.CSharp.DataFaker.Internal.Extensions;

internal static partial class TypeExtensions
{
    private const BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Static;

    public static Faker<TValue>? GetFakerPropertyValue<TValue>(this Type type)
        where TValue : class
    {
        string propertyName = typeof(TValue).GetFakerPropertyName();
        string fakerPropertyName = $"Fake{propertyName}";

        return type.GetProperty(fakerPropertyName, Flags)?.GetValue(null) as Faker<TValue>;
    }
}
