using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
    public static partial class MyEnumerable
    {
        public static IEnumerable<TResult> MySelect<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector
        )
        {
            return Enumerable.Select(source, selector);
        }

        public static IEnumerable<TResult> MySelect<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, TResult> selector
        )
        {
            return Enumerable.Select(source, selector);
        }
    }
}
