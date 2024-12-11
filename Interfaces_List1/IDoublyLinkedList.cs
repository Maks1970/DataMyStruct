using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_List
{
    public interface IDoublyLinkedNode : ILinkedNode
    {
        public IDoublyLinkedNode? Previous { get; set; }
    }

    public interface IDoublyLinkedList : IMyLinkedList
    {
        void Remove(object obj);
        public void RemoveFirst();
        public void RemoveLast();

    }
}
