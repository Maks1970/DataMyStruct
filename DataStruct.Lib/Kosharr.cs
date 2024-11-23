using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace DataStruct.Lib
{
    public class Kosharr
    {

        private object[] _innerArray;
        public int count { get; private set; }
        public int countR { get; private set; }
        public Kosharr(params object[] obj)
        {
            _innerArray = obj;
            foreach (object o in _innerArray)
            {
                count++;
            }
        }


        public object this[int index]
        {
            get => _innerArray[index];     // Читання значення за індексом
            set => _innerArray[index] = value; // Запис значення за індексом
        }

        public void Add(object obj)
        {
            object[] TempInnerArray = new object[count + 1];
            for (int i = 0; i < count; i++)
            {
                TempInnerArray[i] = _innerArray[i];
            }
            TempInnerArray[count] = obj;
            _innerArray = TempInnerArray;
            count++;
        }

        public void Insert(int num, object obj)
        {
            _innerArray[num - 1] = obj;
        }

        public bool RemoveAt(int num)
        {
            return true;
        } 
        public bool Remove(object obj)
        {
            bool rem = false;
            object[] tempInnerArray = new object[count];
            int index = -1;
            countR = count - 1;
            foreach (object o in _innerArray) 
            {
                index++;
                if (o.Equals(obj)&& rem==false)
                {
                    
                    rem = true;
                    break;
                }
              
            }
            for (int i = 0;i< countR; i++)
            {
                if (index == i && rem == true)
                {
                    tempInnerArray[i] = _innerArray[i + 1];
                }
                else
                {
                    if (i< index)
                    {
                        tempInnerArray[i] = _innerArray[i];
                    }
                    else
                    {
                        tempInnerArray[i] = _innerArray[i+1];
                    } 

                }
                
            }

            countR = count - countR;
            count = count - countR;
            countR = count + countR; 
            _innerArray = tempInnerArray;
            return rem;
        }

    }
}
