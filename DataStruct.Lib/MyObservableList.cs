using Interfaces_List;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct.Lib
{

    public class MyObservableList<T> : IMyCollection<T>
    {
        private ListKosh<T> _innerList = new ListKosh<T>();
        public event EventHandler<CollectionChanged<T>> OnChange;
        
        //public void MyHandle(object? sender, CollectionChanged<T> dd )
        //{
        //    Console.WriteLine($"Дiя: {dd.Change}, Елемент: {dd.Item}");
        //}
        public MyObservableList(params T[] items) 
        {
            foreach (var item in items)
            {
                _innerList.Add(item);
            }
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Індекс виходить за межі масиву.");
                }
                return _innerList[index]; // Читання значення за індексом
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Індекс виходить за межі масиву.");
                }
                _innerList[index] = value; // Запис значення за індексом
            }
        }
        public void Add(T item)
        {
            _innerList.Add(item);
            OnChange?.Invoke(this, new CollectionChanged<T>(Changes.Add, item));
        }
        public void Insert(int index ,T item) 
        {
            _innerList.Insert(index,item);
            OnChange?.Invoke(this, new CollectionChanged<T>(Changes.Insert, item));
        }
        public void Remove(T item)
        {
            _innerList.Remove(item);
            OnChange?.Invoke(this, new CollectionChanged<T>(Changes.Remove, item));
        }
        public void RemoveAt(int index)
        {
            _innerList.RemoveAt(index);
            OnChange?.Invoke(this, new CollectionChanged<T>(Changes.Remove, _innerList[index]));
        }
        public bool Contains(T item) => _innerList.Contains(item);
        public T[] ToArray() => _innerList.ToArray();
        public int Count => _innerList.Count;
        public void Clear() => _innerList.Clear();

        public IEnumerator<T> GetEnumerator()
        {
            return new MyObservableListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public class MyObservableListEnumerator : IEnumerator<T>
        {
            private readonly MyObservableList<T> _innerList;
            private  int _index=-1;

            public MyObservableListEnumerator(MyObservableList<T> list)
            {
                this._innerList = list;
            }

            public T Current => _innerList[_index];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
               
            }

            public bool MoveNext()
            {
                _index++;
                return _index < _innerList.Count;
            }

            public void Reset()
            {
                _index = -1;
            }
        }
    }
    public enum Changes
    {
        Add,
        Remove,
        Insert
    }
    public class CollectionChanged<T> : EventArgs
    {
        public Changes Change;
        public T Item;

        public CollectionChanged(Changes change, T item)
        {
            Change = change;
            Item = item;
        }

    }
}
