using Interfaces_List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStruct.Lib
{
    public class NodeList<T> : ILinkedNode<T>
    {
        public T Data { get ;} 
        public ILinkedNode<T> Next { get; set; } 

        public NodeList(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
