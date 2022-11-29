using System.Collections.Generic;
using System.Linq;

namespace ReadGosuslugi.Core.Extensions
{
    /// <summary>
    /// Various linq extensions used across application
    /// </summary>
    public static class LinqExtensions
    {
        public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }
    }
}
