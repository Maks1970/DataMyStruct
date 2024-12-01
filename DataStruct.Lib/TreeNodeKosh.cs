using static DataStruct.Lib.BinaryTreeNodeKosh;

namespace DataStruct.Lib
{
    public class TreeNodeKosh
    {
        public int Data { get;}
        public TreeNodeKosh left { get; set; }
        public TreeNodeKosh right { get; set; }
        public TreeNodeKosh(int value)
        {
            Data = value;
            left = null;
            right = null;
        }
    }
}
