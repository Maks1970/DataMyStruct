using Interfaces_List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStruct.Lib
{
    public class NodeList : ILinkedNode
    {
        public object Data { get ;} 
        public ILinkedNode Next { get; set; } 

        public NodeList(object data)
        {
            Data = data;
            Next = null;
        }
    }
}
