using System;
using System.Collections.Generic;
using System.Linq;

namespace Ace.CSharp.DataFaker.Extensions;
public static class TypeExtensions
{
    private const string Of = "Of";
    private const string And = "And";

    private static readonly IDictionary<string, string> cache = new Dictionary<string, string>();
    private static readonly IDictionary<string, string> replacements = new Dictionary<string, string>()
    {
        { "Int16", "Short" },
        { "UInt16", "UShort" },
        { "Int32", "Int" },
        { "UInt32", "UInt" },
        { "Int64", "Long" },
        { "UInt64", "ULong" },
    };

    public static string GetFakerExhaustiveName(this Type type)
    {
        if (cache.ContainsKey(type.FullName))
        {
            return cache[type.FullName];
        }

        string result = type.IsGenericType switch
        {
            true => DetermineGenericExhaustiveName(type),
            false => DetermineNonGenericExhaustiveName(type)
        };

        _ = cache.TryAdd(type.FullName, result);

        return result;

        static string DetermineGenericExhaustiveName(Type type)
        {
            var argsNames = type
                .GetGenericArguments()
                .Select(t => GetFakerExhaustiveName(t))
                .ToList();

            string typeName = type.GetFakerShortName();
            string argsName = string.Join(And, argsNames);

            return $"{ typeName }{ Of }{ argsName }";
        }

        static string DetermineNonGenericExhaustiveName(Type type)
        {
            string typeName = type.GetFakerShortName();

            return typeName;
        }
    }

    private static string GetFakerShortName(this Type type)
    {
        return type.IsGenericType switch
        {
            true => DetermineGenericShortName(type),
            false => DetermineNonGenericShortName(type),
        };

        static string DetermineGenericShortName(Type type)
        {
            string typeName = type.Name;
            int length = typeName.IndexOf('`', StringComparison.Ordinal);

            return typeName.AsSpan(0, length).ToString();

        }

        static string DetermineNonGenericShortName(Type type)
        {
            return replacements.ContainsKey(type.Name) switch
            {
                true => replacements[type.Name],
                false => type.Name
            };
        }
    }
}
