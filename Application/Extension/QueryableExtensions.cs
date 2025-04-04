using System.Linq.Expressions;

namespace Application.Extension;

internal static class QueryableExtensions
{
    public static IQueryable<TSource> WhereIf<TSource>(
        this IQueryable<TSource> source,
        bool condition,
        Expression<Func<TSource, bool>> predicate)
        => condition
            ? source.Where(predicate)
            : source;
}
