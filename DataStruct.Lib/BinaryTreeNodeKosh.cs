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
    public class BinaryTreeNodeKosh<T> : IBinaryTree<T> where T : IComparable<T>
    {
        public ITreeNodeKosh<T> root { get;  set; }
        public T Root => root.Data ?? default;
        public int Count { get; private set; }
        public BinaryTreeNodeKosh(params T[] obj)
        {
            Count = 0;
            foreach (T i in obj)
            {
                Add(i);
                
            }
        }

        public BinaryTreeNodeKosh(T rootValue)
        {
            root = new TreeNodeKosh<T>(rootValue);
            Count = 0;
        }

        public void Add(T value)
        {

            if(value is T item)
            {
                root = InnerAdd(root, item);
                Count++;
            }
            
        }

        private ITreeNodeKosh<T> InnerAdd(ITreeNodeKosh<T> node, T value)
        {
            if (node == null)
            {
               node = new TreeNodeKosh<T>(value);
                return node;
            }
            if (value.CompareTo(node.Data) == 0)
            {
                Console.WriteLine($"{node.Data} present in the tree");
                return node;
            }
            if (value.CompareTo(node.Data) < 0)
            {
                node.Left = InnerAdd(node.Left, value);
            }
            else if (value.CompareTo(node.Data) > 0)
            {
                node.Right = InnerAdd(node.Right, value);
            }
            return node;
        }

        public bool Contains(T value)
        {
                return ContainsRec(root, value);
        }

        private bool ContainsRec(ITreeNodeKosh<T> node, T value)
        {
            if (node == null) return false;
            if (node.Data.CompareTo(value)==0) return true;
            return value.CompareTo(node.Data) < 0
            ? ContainsRec(node.Left, value)
            : ContainsRec(node.Right, value);
        }
        public void Clear()
        { 
            root = default;
        }
        public T[] ToArray()
        {
            T[] mas = new T[Count];  
            int currentIndex = 0; 
            PreOrderTraversalRec(root, mas, ref currentIndex);
            return mas;
        }
        private void PreOrderTraversalRec(ITreeNodeKosh<T> node, T[] mas, ref int currentIndex)
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
