using Interfaces_List;
using static DataStruct.Lib.BinaryTreeNodeKosh;

namespace DataStruct.Lib
{
    public class TreeNodeKosh : ITreeNodeKosh
    {
        public int Data { get;}
        public ITreeNodeKosh Left { get; set; }
        public ITreeNodeKosh Right { get; set; }
        public TreeNodeKosh(int value)
        {
            Data = value;
            Left = null;
            Right = null;
        }
    }
}
