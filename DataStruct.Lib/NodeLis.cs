using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStruct.Lib
{
    public class NodeLis
    {
        public object Data { get; set; } 
        public NodeLis Next { get; set; } 

        public NodeLis(object data)
        {
            Data = data;
            Next = null;
        }
    }
}
