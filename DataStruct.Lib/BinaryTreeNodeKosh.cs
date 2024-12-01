using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStruct.Lib
{
    public class BinaryTreeNodeKosh
    {
        private TreeNodeKosh root { get;  set; }
        public int Root => root?.Data ?? 0;
        public int Count { get; private set; }
        public BinaryTreeNodeKosh(params int[] obj)
        {
            Count = 0;
            foreach (int i in obj)
            {
                Add(i);
                
            }
        }

        public BinaryTreeNodeKosh(int rootValue)
        {
            root = new TreeNodeKosh(rootValue);
            Count = 0;
        }

        public void Add(int value)
        {
            root = InnerAdd(root, value);
            Count++;
        }

        private TreeNodeKosh InnerAdd(TreeNodeKosh node, int value)
        {
            if (node == null)
            {
                node = new TreeNodeKosh(value);
                return node;
            }
            if (value == node.Data)
            {
                Console.WriteLine($"{node.Data} present in the tree");
                return node;
            }
            if (value < node.Data)
            {
                node.left = InnerAdd(node.left, value);
            }
            else if (value > node.Data)
            {
                node.right = InnerAdd(node.right, value);
            }
            return node;
        }

        public bool Contains(int value)
        {
            return ContainsRec(root, value);
        }

        private bool ContainsRec(TreeNodeKosh node, int value)
        {
            if (node == null) return false;
            if (node.Data == value) return true;
            return value < node.Data ? ContainsRec(node.left, value) : ContainsRec(node.right, value);
        }
        public void Clear()
        { 
            root = null;
        }
        public int[] ToArray()
        {
            int[] mas = new int[Count];  
            int currentIndex = 0; 
            PreOrderTraversalRec(root, mas, ref currentIndex);
            return mas;
        }
        private void PreOrderTraversalRec(TreeNodeKosh node, int[] mas, ref int currentIndex)
        {
            if (node != null)
            {
                mas[currentIndex++] = node.Data;
                PreOrderTraversalRec(node.left, mas, ref currentIndex);
                PreOrderTraversalRec(node.right, mas, ref currentIndex);
            }
        }

    }
}
