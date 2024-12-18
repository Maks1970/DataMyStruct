using Interfaces_List;
using System;
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
        public EventHandler<CollectionChanged<T>> OnChange;
        
        public void MyHandle(object? sender, CollectionChanged<T> dd )
        {
            Console.WriteLine($"Дiя: {dd.Change}, Елемент: {dd.Item}");
        }
        public MyObservableList(params T[] items) 
        {
            foreach (var item in items)
            {
                _innerList.Add(item);
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
