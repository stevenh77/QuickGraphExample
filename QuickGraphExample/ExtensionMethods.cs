using System.Collections.Generic;
using System.Linq;

namespace QuickGraphExample
{
    public static class ExtensionMethods
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }
    }
}