using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
    internal class MySelectEnumerator<TSource, TResult> : IEnumerator<TResult>
    {
        private bool _hasNext = true;
        private TResult _current;

        private readonly Func<TSource, TResult> _selector;
        private readonly IEnumerator<TSource> _sourceEnumerator;

        public MySelectEnumerator(
            Func<TSource, TResult> selector,
            IEnumerator<TSource> sourceEnumerator
        )
        {
            _selector = selector;
            _sourceEnumerator = sourceEnumerator;
        }

        public TResult Current
        {
            get
            {
                if (!_hasNext)
                {
                    throw new InvalidOperationException();
                }

                return _current;
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            _hasNext = _sourceEnumerator.MoveNext();

            if (_hasNext)
            {
                _current = _selector(_sourceEnumerator.Current);
            }

            return _hasNext;
        }

        public void Reset()
        {
            _sourceEnumerator.Reset();
        }

        public void Dispose()
        {
            _sourceEnumerator.Dispose();
            _current = default;
        }
    }
}
