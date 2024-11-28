using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStruct.Lib
{
 


    public class LinkedKosh
    {
        public  NodeLis Head;
        public NodeLis? First   { get; protected set; }
        public NodeLis? Last { get; protected set; }

        public int Count {  get; private set; }
        public LinkedKosh()
        {
            Count = 0;
            Head = null;
        }
        public LinkedKosh(params object[] obj)
        {
            Count = 0;
            foreach (object o in obj) 
            {
                Add(o);
                Count++;
            }
        }

        public void AddFirst(object obj)
        {
            NodeLis newNode = new NodeLis(obj);
            NodeLis headNode = Head;
            if (Head != newNode)
            {
                
                newNode.Next = headNode;
                Head = newNode;
                
                First = newNode;
            }
            else
            {
                NodeLis currentNode = Head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = newNode;
                Last = currentNode.Next;
            }
            Count++;
        }
        public void Add(object obj)
        {
            NodeLis newNode = new NodeLis(obj);
            if(Head == null)
            {
                Head = newNode;
                First = newNode;
            }
            else
            {
                NodeLis  currentNode = Head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = newNode;
                Last = currentNode.Next;
            }
            
        }
        
        public void Insert(int index, object obj)
        {
            int i = 0;
            Count++;
            NodeLis newNode = new NodeLis(obj);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                NodeLis currentNode = Head;
                while (currentNode.Next != null)
                {
                    
                    if (i==index-1)
                    {
                        newNode.Next= currentNode.Next;
                        currentNode.Next = newNode;
                        
                    }
                    currentNode = currentNode.Next;
                    i++;
                }
                
            }
        }

        public void Clear()
        {
            NodeLis current = Head;
            while (current != null)
            {
                NodeLis next = current.Next; 
                current.Next = null;                     
                current = next;                           
            }
            Head = null;
            Count = 0;
        }

        public bool Contains(object obj)
        {

            NodeLis current = Head;
            while (current != null)
            {
                if(current.Data.Equals(obj))
                {
                    return true;
                }
                else
                current = current.Next;
            }
            return false;
        }

        public object[] ToArray()
        {
            //object[] mas;//= new object[Count];
            Kosharr mas = new Kosharr();
            NodeLis current = Head;
            while (current != null)
            {
                mas.Add(current.Data);
                current = current.Next;
            }
            //for (int i = 0;i<Count; i++)
            //{
            //    mas[i] = Get(i);
            //}
            return mas.ToArray();
        }
        public object Get(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Index must be non-negative");

            NodeLis current = Head;
            int currentIndex = 0;
            while (current != null)
            {
                if (currentIndex == index)
                    return current.Data;

                current = current.Next;
                currentIndex++;
            }
            throw new ArgumentOutOfRangeException("Index exceeds the bounds of the list");
        }

    }
}
