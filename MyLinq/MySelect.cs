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
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(selector);

            return new EchoEnumerable<TResult>(() =>
            {
                var sourceEnumerator = source.GetEnumerator();
                var enumerator = new MySelectEnumerator<TSource, TResult>(
                    selector,
                    sourceEnumerator
                );

                return enumerator;
            });
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
