using Ace.CSharp.DataFaker.Exceptions;

namespace Ace.CSharp.DataFaker.Internal.Extensions;

internal static partial class TypeExtensions
{
    public static Faker<T> GetFaker<T>(this Type @this)
        where T : class
    {
        return @this.GetFakerPropertyValue<T>() ?? throw new FakerNotFoundException<T>();
    }

    public static Faker<T> GetFakerOrDefault<T>(this Type @this)
        where T : class
    {
        return @this.GetFakerPropertyValue<T>() ?? new Faker<T>();
    }
}
