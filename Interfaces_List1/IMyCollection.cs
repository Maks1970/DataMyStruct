using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_List
{
    public interface IMyCollection
    {
        int Count { get; }
        void Add(object item);
        bool Contains(object item);
        void Clear();
        object[] ToArray();
    }
}
