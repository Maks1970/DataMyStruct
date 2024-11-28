using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace DataStruct.Lib
{
    public class Kosharr
    {

        private object[] _innerArray;
        public int Count { get; private set; }

        public Kosharr(params object[] obj)
        {
            _innerArray = obj;
            foreach (object o in _innerArray) 
            {
                Count++;
            }
        }


        public object this[int index]
        {
            get => _innerArray[index];     // Читання значення за індексом
            set => _innerArray[index] = value; // Запис значення за індексом
        }

        public void Add(object obj)
        {
            object[] TempInnerArray = new object[Count + 1];
            for (int i = 0; i < Count; i++)
            {
                TempInnerArray[i] = _innerArray[i];
            }
            TempInnerArray[Count] = obj;
            _innerArray = TempInnerArray;
            Count++;
        }

        public void Insert(int num, object obj)
        {
            object ob;
            Count++;
            object[] tempInnerArray = new object[Count];
            for (int i = 0; i < Count; i++)
            {
                if(i < num)
                {
                    tempInnerArray[i] = _innerArray[i];
                }
                else if (i == num)
                {
                    ob = _innerArray[i];
                    tempInnerArray[i] = obj;
                  //  i++;
                }
                else if (i > num)
                {
                    tempInnerArray[i] = _innerArray[i-1];
                }
            }
            _innerArray = tempInnerArray;
        }

        public bool Remove(object obj)
        {
            bool rem = false;
            int countR = Count;
            object[] tempInnerArray = new object[Count];
            int index = -1;
            countR = Count - 1;
            foreach (object o in _innerArray)
            {
                index++;
                if (o.Equals(obj) && rem == false)
                {

                    rem = true;
                    break;
                }

            }
            for (int i = 0; i < countR; i++)
            {
                if (index == i && rem == true)
                {
                    tempInnerArray[i] = _innerArray[i + 1];
                }
                else
                {
                    if (i < index)
                    {
                        tempInnerArray[i] = _innerArray[i];
                    }
                    else
                    {
                        tempInnerArray[i] = _innerArray[i + 1];
                    }

                }

            }

            countR = Count - countR;
            Count = Count - countR;
            countR = Count + countR;
            _innerArray = tempInnerArray;
            return rem;
        }

        public bool RemoveAt(int num)
        {
            bool rem = false;
            int countR = Count;
            object[] tempInnerArray = new object[Count];
            int index = num - 1;
            countR = Count - 1;
            for (int i = 0; i < countR; i++)
            {
                if (index == i && rem == false)
                {
                    tempInnerArray[i] = _innerArray[i + 1];
                    rem = true;
                }
                else
                {
                    if (i < index)
                    {
                        tempInnerArray[i] = _innerArray[i];
                    }
                    else
                    {
                        tempInnerArray[i] = _innerArray[i + 1];
                    }

                }

            }

            countR = Count - countR;
            Count = Count - countR;
            countR = Count + countR;
            _innerArray = tempInnerArray;
            return rem;
        }

        void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                _innerArray[i] = null;
            }

            Count = 0;
        }

        public bool Contains(object obj)
        {
            foreach (object ob in _innerArray)
            {
                if (ob.Equals(obj)) return true;
            }
            return false;
        }

        public int IndexOf(object obj)
        {
            int index = -1;
            foreach (object ob in _innerArray)
            {
                index++;
                if (ob.Equals(obj)) return index;
            }
            return -1;
        }

        public object [] ToArray()
        {
          
            return _innerArray;
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
