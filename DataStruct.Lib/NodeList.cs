using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStruct.Lib
{
    public class NodeList
    {
        public object Data { get ;} 
        public NodeList Next { get; set; } 

        public NodeList(object data)
        {
            Data = data;
            Next = null;
        }
    }
}
