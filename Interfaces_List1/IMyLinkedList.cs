
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Interfaces_List
{

    public interface ILinkedNode
    { 
        object Data {  get; }
        ILinkedNode Next { get; set; } 
    }
    public interface IMyLinkedList : IMyCollection
    {
        public object? First { get; }
        public object? Last { get; }
        void AddFirst(object item);
        void Insert(int index, object item);


    }
}
