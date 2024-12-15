using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_List
{
    public interface IDoublyLinkedNode<T> : ILinkedNode<T>
    {
        public IDoublyLinkedNode<T>? Previous { get; set; }
    }

    public interface IDoublyLinkedList<T> : IMyLinkedList<T>
    {
        void Remove(T obj);
        public void RemoveFirst();
        public void RemoveLast();

    }
}
