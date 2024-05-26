using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
    internal class EchoEnumerable<T>(Func<IEnumerator<T>> _enumeratorFactory) : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator() => _enumeratorFactory();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
