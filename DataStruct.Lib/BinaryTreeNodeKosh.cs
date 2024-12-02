using Interfaces_List;
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
    public class BinaryTreeNodeKosh : IBinaryTree
    {
        public ITreeNodeKosh root { get;  set; }
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

        public void Add(object value)
        {

            if(value is int item)
            {
                root = InnerAdd(root, item);
                Count++;
            }
            
        }

        private ITreeNodeKosh InnerAdd(ITreeNodeKosh node, int value)
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
                node.Left = InnerAdd(node.Left, value);
            }
            else if (value > node.Data)
            {
                node.Right = InnerAdd(node.Right, value);
            }
            return node;
        }

        public bool Contains(object value)
        {
            if (value is int item) // Переводимо object до int
            {
                return ContainsRec(root, item);
            }
            else return false;
            //return ContainsRec(root, value);
        }

        private bool ContainsRec(ITreeNodeKosh node, int value)
        {
            if (node == null) return false;
            if (node.Data == value) return true;
            return value < node.Data ? ContainsRec(node.Left, value) : ContainsRec(node.Right, value);
        }
        public void Clear()
        { 
            root = null;
        }
        public object[] ToArray()
        {
            object[] mas = new object[Count];  
            int currentIndex = 0; 
            PreOrderTraversalRec(root, mas, ref currentIndex);
            return mas;
        }
        private void PreOrderTraversalRec(ITreeNodeKosh node, object[] mas, ref int currentIndex)
        {
            if (node != null)
            {
                mas[currentIndex++] = node.Data;
                PreOrderTraversalRec(node.Left, mas, ref currentIndex);
                PreOrderTraversalRec(node.Right, mas, ref currentIndex);
            }
        }

    }
}
