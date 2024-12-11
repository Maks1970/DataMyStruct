using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Interfaces_List
{
    public interface IMyList : IMyCollection
    {
        object this[int index] { get; set; }

        void Insert(int index, object item);
        bool Remove(object item);
        bool RemoveAt(int index);
        int IndexOf(object item);
        void Reverse();
    }
}
