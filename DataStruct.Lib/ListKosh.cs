using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace DataStruct.Lib
{
    public class ListKosh
    {
        private object[] _innerArray;
        public int Count { get; private set; }

        public ListKosh(params object[] item)
        {
            if (item == null || item.Length == 0)
            {
                // Якщо item дорівнює null або порожній, створюємо масив за замовчуванням з розміром 4
                _innerArray = new object[4];
                Count = 0;
            }
            else
            {
                _innerArray = new object[item.Length];
                for (int i = 0; i < _innerArray.Length; i++)
                {
                    _innerArray[i] = item[i];
                }
                Count = item.Length;
            }
        }

        public object this[int index]
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

        public void Add(object item)
        {
            object[] tempInnerArray = new object[Count + 1];
            for (int i = 0; i < Count; i++)
            {
                tempInnerArray[i] = _innerArray[i];
            }
            tempInnerArray[Count] = item;
            _innerArray = tempInnerArray;
            Count++;
        }

        public void Insert(int index, object item)
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
            var newArray = new object[_innerArray.Length * 2];
            for (int i = 0; i < _innerArray.Length; i++)
            {
                newArray[i] = _innerArray[i];
            }
            _innerArray = newArray;
        }

        public bool Remove(object item)
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
            _innerArray[Count - 1] = null;
            Count--;
            return true;
        }

        void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                _innerArray[i] = null;
            }

            Count = 0;
        }

        public bool Contains(object item)
        {
            foreach (object ob in _innerArray)
            {
                if (ob.Equals(item)) return true;
            }
            return false;
        }

        public int IndexOf(object item)
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

        public object [] ToArray()
        {
            var newArray = new object[Count];
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
                object temp = _innerArray[left];
                _innerArray[left] = _innerArray[right];
                _innerArray[right] = temp;

                left++;
                right--;
            }
        }

    }
}
