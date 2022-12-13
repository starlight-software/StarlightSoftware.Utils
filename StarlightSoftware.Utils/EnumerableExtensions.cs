using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StarlightSoftware.Utils;

public static class EnumerableExtensions
{
    /// <summary>
    /// Determines if a sequence contains no elements.
    /// </summary>
    /// <returns>true if the sequence contains no elements, otherwise false</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static bool None<T>(this IEnumerable<T> source) => !source.Any();
    
    /// <summary>
    /// Determines if any all elements of a sequence fail to satisfy a condition.
    /// </summary>
    /// <returns>true if all elements in the sequence fail the specified predicate, otherwise false</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static bool None<T>(this IEnumerable<T> source, Func<T, bool> predicate) => !source.Any(predicate);

    /// <summary>
    /// Determines if a sequence contains no elements.
    /// </summary>
    /// <returns>true if the sequence contains no elements, otherwise false</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static bool None<T>(this IQueryable<T> source) => !source.Any();

    /// <summary>
    /// Determines if a sequence contains no elements.
    /// </summary>
    /// <returns>true if the sequence contains no elements, otherwise false</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static bool None<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate) => !source.Any(predicate);
}

