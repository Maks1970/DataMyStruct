using Interfaces_List;
using System;
using System.Collections;
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

        public IEnumerator<T> GetEnumerator()
        {
            return new BinaryTreeNodeKoshEnumerator(root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class BinaryTreeNodeKoshEnumerator : IEnumerator<T>
        {
            private ITreeNodeKosh<T> _root;
            private ITreeNodeKosh<T> _current;
            private ITreeNodeKosh<T> _predecessor;
            public BinaryTreeNodeKoshEnumerator(ITreeNodeKosh<T> root)
            {
                _root = root ?? throw new ArgumentNullException(nameof(root), "Root cannot be null");
                _current = null; // Початкове значення для _current
                _predecessor = null;
            }

            public T Current
            {
                get
                {
                    if (_current == null)
                        throw new InvalidOperationException("Enumeration has not started. Call MoveNext.");
                    return _current.Data;

                }
            } /*=>  _current.Data;*/


            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_current == null)
                {
                    // Перший крок: встановити _current на корінь дерева
                    _current = _root;
                    return _current != null; // Якщо дерево порожнє, одразу завершуємо ітерацію
                }

                while (_current != null)
                {
                    if (_current.Left == null)
                    {
                        // Немає лівого піддерева, обробляємо поточний вузол
                        var result = _current;
                        _current = _current.Right; // Переходимо до правого піддерева
                        return result != null;
                    }
                    else
                    {
                        // Знайти інфіксного попередника
                        _predecessor = _current.Left;
                        while (_predecessor.Right != null && _predecessor.Right != _current)
                        {
                            _predecessor = _predecessor.Right;
                        }

                        if (_predecessor.Right == null)
                        {
                            // Встановити тимчасове посилання
                            _predecessor.Right = _current;
                            _current = _current.Left;
                        }
                        else
                        {
                            // Видалити тимчасове посилання та обробити поточний вузол
                            _predecessor.Right = null;
                            var result = _current;
                            _current = _current.Right;
                            return result != null;
                        }
                    }
                }

                return false; // Кінець дерева
            }

            public void Reset()
            {
                _current = _root;
            }
        }
    }
}
