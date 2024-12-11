using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_List
{
    public interface IMyCollection<T>
    {
        int Count { get; }
        void Add(T item);
        bool Contains(T item);
        void Clear();
        T[] ToArray();
    }
}
