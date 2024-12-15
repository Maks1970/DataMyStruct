
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Interfaces_List
{

    public interface ILinkedNode<T>
    { 
        T Data { get; }
        ILinkedNode<T> Next { get; set; } 
    }
    public interface IMyLinkedList<T> : IMyCollection<T>
    {
         T? First { get; }
         T? Last { get; }
        void AddFirst(T item);
        void Insert(int index, T item);


    }
}
