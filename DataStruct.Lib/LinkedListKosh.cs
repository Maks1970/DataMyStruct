using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Interfaces_List;

namespace DataStruct.Lib
{
    public class LinkedListKosh<T> : IMyLinkedList<T>
    {
        public ILinkedNode<T> Head;
        public ILinkedNode<T>? Tail { get; protected set; }

        public T? First
        {
            get => Head.Data;  // Повертає значення (Data) першої ноди, якщо вона є

        }
        public T? Last
        {
            get => Tail.Data;  // Повертає значення (Data) першої ноди, якщо вона є

        }

        

        public int Count {  get; protected set; }
        public LinkedListKosh()
        {
            Count = 0;
            Head = null;
        }
        public LinkedListKosh(params T[] item)
        {
            Count = 0;
            foreach (T o in item) 
            {
                Add(o);
            }
        }

        public virtual void AddFirst(T item)
        {
            ILinkedNode<T> newNode = new NodeList<T>(item);
            ILinkedNode<T> headNode = Head;
            if (Head != newNode)
            {
                newNode.Next = headNode;
                Head = newNode;
            }
            else
            {
                ILinkedNode<T> currentNode = Head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = newNode;
                Tail = currentNode.Next;
            }
            Count++;
        }
        public virtual void Add(T item)
        {
            ILinkedNode<T> newNode = new NodeList<T>(item);
            if(Head == null)
            {
                Head = newNode;
            }
            else
            {
                ILinkedNode<T> currentNode = Head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = newNode;
                Tail = currentNode.Next;
            }
            Count++;

        }
        
        public  void Insert(int index, T item)
        {
            int i = 0;
            Count++;
            ILinkedNode<T> newNode = new NodeList<T>(item);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                ILinkedNode<T> currentNode = Head;
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

        public bool Contains(T item)
        {

            ILinkedNode<T> current = Head;
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

        public T[] ToArray()
        {
            ILinkedNode<T> current = Head;
            T[] result = new T[Count];
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
        public T Get(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Index must be non-negative");

            ILinkedNode<T> current = Head;
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

        public IEnumerator<T> GetEnumerator()
        {
            if (Head == null) yield break;  // Якщо перший елемент відсутній, зупиняємо ітерацію.

            ILinkedNode<T> firstNode = Head;  // Встановлюємо поточний елемент на перший.
            while (firstNode != null)
            {
                yield return firstNode.Data;  // Повертаємо значення поточного елемента.
                firstNode = firstNode.Next;  // Переходимо до наступного елемента.
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        //public class LinkedListKoshEnumerator : IEnumerator<T>
        //{
        //    private  ILinkedNode<T> _firstNode;
        //    private  ILinkedNode<T> _node;

        //    public LinkedListKoshEnumerator(ILinkedNode<T> firstNode)
        //    {
        //        this._firstNode = firstNode;
        //        _node = null;
        //    }

        //    public T Current => _node.Data;

        //    object IEnumerator.Current => Current;

        //    public void Dispose()
        //    {
        //    }

        //    public bool MoveNext()
        //    {
        //        if (_firstNode == null) return false; 
        //        _node = _firstNode; 
        //        _firstNode = _node.Next;
        //        return _node != null;
        //    }

        //    public void Reset()
        //    {
        //        _node = _firstNode;
        //    }
        //}
    }
   
}
