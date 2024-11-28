using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStruct.Lib
{
    public class BinaryTreeNodeKosh
    {
        public NodeKosh root { get; private set; }
        public int count { get; private set; }

        public BinaryTreeNodeKosh(params int[] obj)
        {
            count = 0;
            foreach (int i in obj)
            {
                Insert(i);
                count++;
            }
        }
        public BinaryTreeNodeKosh(int rootValue)
        {
            root = new NodeKosh(rootValue);
        }

        public void Insert(int value)
        {
            root = InsertRec(root, value);
        }
        private NodeKosh InsertRec(NodeKosh node, int value)
        {
            
            if (node == null)
            {
                node = new NodeKosh(value);
                return node;
            }
            if (value == node.data)
            {
                Console.WriteLine($"{node.data} present in the tree");
                return node;
            }
            if (value < node.data)
            {
                node.left = InsertRec(node.left, value);
            }
            else if (value > node.data)
            {
                node.right = InsertRec(node.right, value);
            }
            return node;
        }
        public void Add(int item) 
        {
            Insert(item);
        }

        public bool Contains(int value)
        {
            return ContainsRec(root, value);
        }

        private bool ContainsRec(NodeKosh node, int value)
        {
            if (node == null) return false;

           
            if (node.data == value) return true;

            return value < node.data ? ContainsRec(node.left, value) : ContainsRec(node.right, value);
        }
        public void Clear()
        { 
            ConClear(root);
            root = null;
        }
        private void ConClear(NodeKosh node)
        {
            if (node.left != null)
            {
                
                ConClear(node.left);
                ConClear(node.right);
                node = null;
            }
        }
        public int[] ToArray()
        {
            Kosharr kosharr = new Kosharr();
            PreOrderTraversalRec(root, kosharr);
            int[] mas = new int[kosharr.Count];
            for (int i = 0;i<count; i++)
            {
                mas[i] = (int)kosharr[i];
            }
            return mas;
        }
        private void PreOrderTraversalRec(NodeKosh node, Kosharr visit)
        {
            if (node != null)
            {
                visit.Add(node.data);
                PreOrderTraversalRec(node.left, visit);
                PreOrderTraversalRec(node.right, visit);
            }
        }

    }
}
