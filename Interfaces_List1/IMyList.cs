using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Interfaces_List
{
    public interface IMyList <T> : IMyCollection<T>
    {
        T this[int index] { get; set; }

        void Insert(int index, T item);
        bool Remove(T item);
        bool RemoveAt(int index);
        int IndexOf(T item);
        void Reverse();
    }
}
