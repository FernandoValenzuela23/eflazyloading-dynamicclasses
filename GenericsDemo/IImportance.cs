using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    public interface IImportance<T>
    {
        T MostImportant(T v1, T v2);
    }
}
