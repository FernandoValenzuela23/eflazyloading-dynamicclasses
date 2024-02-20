
using System.Numerics;

namespace GenericsDemo
{
    public class MathOperations<T> where T : INumber<T>
    {
        public T Add(T a, T b)
        {
            return a + b;
        }
    }
}
