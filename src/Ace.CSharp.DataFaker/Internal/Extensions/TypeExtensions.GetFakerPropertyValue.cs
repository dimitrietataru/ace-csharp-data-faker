namespace Ace.CSharp.DataFaker.Internal.Extensions;

internal static partial class TypeExtensions
{
    private const BindingFlags InstanceFlags = BindingFlags.NonPublic | BindingFlags.Instance;
    private const BindingFlags StaticFlags = BindingFlags.NonPublic | BindingFlags.Static;

    public static Faker<TValue>? GetFakerPropertyValue<TValue, TContainer>()
        where TValue : class
        where TContainer : class, new()
    {
        var type = typeof(TContainer);
        string propertyName = typeof(TValue).GetFakerPropertyName();
        string fakerPropertyName = $"Fake{propertyName}";

        var property = type.GetProperty(fakerPropertyName, InstanceFlags);
        object? propertyValue = property?.GetValue(Activator.CreateInstance(type));

        return propertyValue as Faker<TValue>;
    }

    public static Faker<TValue>? GetFakerPropertyValue<TValue>(this Type type)
        where TValue : class
    {
        string propertyName = typeof(TValue).GetFakerPropertyName();
        string fakerPropertyName = $"Fake{propertyName}";

        var property = type.GetProperty(fakerPropertyName, StaticFlags);
        object? propertyValue = property?.GetValue(null);

        return propertyValue as Faker<TValue>;
    }
}
