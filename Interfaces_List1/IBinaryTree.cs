using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_List
{
    public interface ITreeNodeKosh<T> where T : IComparable<T>
    {
        T Data { get;}
        ITreeNodeKosh<T> Left { get; set; }
        ITreeNodeKosh<T> Right { get; set; }

    }

    public interface IBinaryTree<T> : IMyCollection<T> where T : IComparable<T>
    {
        ITreeNodeKosh<T> root { get; set; }
    }
}
