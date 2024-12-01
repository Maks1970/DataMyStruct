﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStruct.Lib
{
    public class LinkedList
    {
        public NodeList Head;

        public object? First
        {
            get => Head?.Data;  // Повертає значення (Data) першої ноди, якщо вона є

        }
        public object? Last
        {
            get => Tail?.Data;  // Повертає значення (Data) першої ноди, якщо вона є

        }

        public NodeList? Tail { get; protected set; }

        public   int Count {  get; protected set; }
        public LinkedList()
        {
            Count = 0;
            Head = null;
        }
        public LinkedList(params object[] item)
        {
            Count = 0;
            foreach (object o in item) 
            {
                Add(o);
            }
        }

        public virtual void AddFirst(object item)
        {
            NodeList newNode = new NodeList(item);
            NodeList headNode = Head;
            if (Head != newNode)
            {
                newNode.Next = headNode;
                Head = newNode;
            }
            else
            {
                NodeList currentNode = Head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = newNode;
                Tail = currentNode.Next;
            }
            Count++;
        }
        public virtual void Add(object item)
        {
            NodeList newNode = new NodeList(item);
            if(Head == null)
            {
                Head = newNode;
            }
            else
            {
                NodeList  currentNode = Head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = newNode;
                Tail = currentNode.Next;
            }
            Count++;

        }
        
        public  void Insert(int index, object item)
        {
            int i = 0;
            Count++;
            NodeList newNode = new NodeList(item);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                NodeList currentNode = Head;
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
            Head = Tail = null;
            Count = 0;

        }

        public bool Contains(object item)
        {

            NodeList current = Head;
            while (current != null)
            {
                if(current.Data.Equals(item))
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
            NodeList current = Head;
            object[] result = new object[Count];
            current = Head;
            int index = 0;

            // Заповнюємо масив елементами
            while (current != null)
            {
                result[index++] = current.Data;
                current = current.Next;
            }

            return result;
        }
        public object Get(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Index must be non-negative");

            NodeList current = Head;
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