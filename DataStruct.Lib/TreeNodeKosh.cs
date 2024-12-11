using Interfaces_List;

namespace DataStruct.Lib
{
    public class TreeNodeKosh<T> : ITreeNodeKosh<T>  where T : IComparable<T>
    { 
        public T Data { get;}
        public ITreeNodeKosh<T> Left { get; set; }
        public ITreeNodeKosh<T> Right { get; set; }
        public TreeNodeKosh(T value)
        {
            Data = value;
            Left = null;
            Right = null;
        }
    }
}
