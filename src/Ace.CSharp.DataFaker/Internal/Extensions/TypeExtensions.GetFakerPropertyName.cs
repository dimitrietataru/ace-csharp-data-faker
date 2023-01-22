namespace Ace.CSharp.DataFaker.Internal.Extensions;

internal static partial class TypeExtensions
{
    private const string Of = "Of";
    private const string And = "And";

    private static readonly IDictionary<string, string> cache = new Dictionary<string, string>();

    public static string GetFakerPropertyName(this Type type)
    {
        string key = type.FullName ?? throw new ArgumentException("Invalid type", nameof(type));

        return cache.GetOrAdd(type.FullName, () => GetFakerExhaustiveNameInternal(type));
    }

    private static string GetFakerExhaustiveNameInternal(this Type type)
    {
        return type.IsGenericType
            ? DetermineExhaustiveFakerNameGeneric(type)
            : DetermineExhaustiveFakerName(type);
    }

    private static string DetermineExhaustiveFakerNameGeneric(Type type)
    {
        string typeName = type.GetFakerShortName();

        string argName = type
            .GetGenericArguments()
            .Select(inner => GetFakerPropertyName(inner))
            .JoinToString(And);

        return $"{typeName}{Of}{argName}";
    }

    private static string DetermineExhaustiveFakerName(Type type)
    {
        string typeName = type.GetFakerShortName();

        return typeName;
    }

    private static string GetFakerShortName(this Type type)
    {
        return type.IsGenericType
            ? DetermineGenericShortName(type)
            : DetermineNonGenericShortName(type);
    }

    private static string DetermineGenericShortName(Type type)
    {
        string typeName = type.Name;
        int length = typeName.IndexOf("`", StringComparison.Ordinal);

        return typeName[..length];
    }

    private static string DetermineNonGenericShortName(Type type)
    {
        var replacements = new Dictionary<string, string>()
        {
            { "Int16", "Short" },
            { "Int32", "Int" },
            { "Int64", "Long" },
            { "Single", "Float" },
            { "UInt16", "UShort" },
            { "UInt32", "UInt" },
            { "UInt64", "ULong" },
        };

        if (replacements.ContainsKey(type.Name))
        {
            return replacements[type.Name];
        }

        return type.Name;
    }
}
