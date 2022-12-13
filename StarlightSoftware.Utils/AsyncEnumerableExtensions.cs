using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace StarlightSoftware.Utils;

public static class AsyncEnumerableExtensions
{
    public static async Task<List<T>> ToListAsync<T>(this IAsyncEnumerable<T> source)
    {
        // ReSharper disable PossibleMultipleEnumeration
        if(source is null) throw new ArgumentNullException(nameof(source));

        List<T> list = new();

        await foreach (T element in source)
        {
            list.Add(element);
        }

        return list;
        // ReSharper restore PossibleMultipleEnumeration
    }
}
