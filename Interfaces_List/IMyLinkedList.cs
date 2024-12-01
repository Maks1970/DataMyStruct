using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_List
{
    internal interface IMyLinkedList
    {
        public object? First { get; set; }
        public object? Last { get; }
        public NodeList Tail { get; set; }
    }
}
