using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_List
{
    public interface ITreeNodeKosh
    {
        int Data { get;}
        ITreeNodeKosh Left { get; set; }
        ITreeNodeKosh Right { get; set; }

    }

    public interface IBinaryTree : IMyCollection
    {
        ITreeNodeKosh root { get; set; }
    }
}
