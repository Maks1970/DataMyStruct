using Interfaces_List;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace DataStruct.Lib
{

    public class ListKosh<T> : IMyList<T>
    {
        private T[] _innerArray; 
        public int Count { get; private set; }

        public ListKosh(params T[] item)
        {
            if (item == null || item.Length == 0)
            {
                // Якщо item дорівнює null або порожній, створюємо масив за замовчуванням з розміром 4
                _innerArray = new T[4];
                Count = 0;
            }
            else
            {
                _innerArray = new T[item.Length];
                for (int i = 0; i < _innerArray.Length; i++)
                {
                    _innerArray[i] = item[i];
                }
                Count = item.Length;
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
                return _innerArray[index]; // Читання значення за індексом
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Індекс виходить за межі масиву.");
                }
                _innerArray[index] = value; // Запис значення за індексом
            }
        }

        public void Add(T item)
        {
            T[] tempInnerArray = new T[Count + 1];
            for (int i = 0; i < Count; i++)
            {
                tempInnerArray[i] = _innerArray[i];
            }
            tempInnerArray[Count] = item;
            _innerArray = tempInnerArray;
            Count++;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Індекс виходить за межі допустимого діапазону.");
            }

            // Якщо внутрішній масив заповнений, розширюємо його
            if (Count == _innerArray.Length)
            {
                ExpandArray();
            }

            // Пересуваємо елементи з кінця до індекса вставки
            for (int i = Count; i > index; i--)
            {
                _innerArray[i] = _innerArray[i - 1];
            }

            // Вставляємо новий елемент
            _innerArray[index] = item;
            Count++;
        }

        private void ExpandArray()
        {
            var newArray = new T[_innerArray.Length * 2];
            for (int i = 0; i < _innerArray.Length; i++)
            {
                newArray[i] = _innerArray[i];
            }
            _innerArray = newArray;
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);
            return index >= 0 && RemoveAt(index);
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Індекс виходить за межі допустимого діапазону.");
            }
            for (int i = index; i < Count - 1; i++)
            {
                _innerArray[i] = _innerArray[i + 1];
            }
            _innerArray[Count - 1] = default;
            Count--;
            return true;
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                _innerArray[i] = default;
            }

            Count = 0;
        }

        public bool Contains(T item)
        {
            foreach (T ob in _innerArray)
            {
                if (ob.Equals(item)) return true;
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_innerArray[i].Equals(item))
                {
                    return i;
                }
            }
            return -1; // Якщо об'єкт не знайдено
        }

        public T [] ToArray()
        {
            var newArray = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                newArray[i]= _innerArray[i];
            }
            return newArray;
        }

        public void Reverse() 
        {
            int left = 0;
            int right = Count - 1;
            while (left < right)
            {
                T temp = _innerArray[left];
                _innerArray[left] = _innerArray[right];
                _innerArray[right] = temp;

                left++;
                right--;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyListInumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class MyListInumerator : IEnumerator<T>
        {
            private readonly ListKosh<T> _list;
            private int _index = -1;
            public T Current => _list[_index];
            public MyListInumerator(ListKosh<T> list)
            {
                this._list = list;
            }
            object IEnumerator.Current => Current;

            

            public bool MoveNext()
            {
                _index++;
                return _index < _list.Count;
            }

            public void Reset()
            {
                _index = -1;
            }
            public void Dispose()
            {

            }
        }
    }
}
