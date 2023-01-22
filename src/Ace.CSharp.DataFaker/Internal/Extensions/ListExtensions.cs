namespace Ace.CSharp.DataFaker.Internal.Extensions;

internal static class EnumerableExtensions
{
    public static string JoinToString(this IEnumerable<string> @this, string separator)
    {
        return string.Join(separator, @this);
    }
}
