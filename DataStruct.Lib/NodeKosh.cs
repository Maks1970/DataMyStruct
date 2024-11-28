using static DataStruct.Lib.BinaryTreeNodeKosh;

namespace DataStruct.Lib
{
    public class NodeKosh
    {

            public int data { get; set; }

            //public object left { get; set; }
            //public object right { get; set; }
        public NodeKosh left;
        public NodeKosh right;
        public NodeKosh(int value)
        {
            data = value;
            left = null;
            right = null;
        }
    }
}
