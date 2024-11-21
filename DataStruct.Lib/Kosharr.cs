using System.Reflection.Metadata.Ecma335;

namespace DataStruct.Lib
{
    public class Kosharr
    {
        //  List<int> df ;
        private int count = 0 ;
        private object[] InnerArray;

        public Kosharr(params object[] obj)
        {
            InnerArray = obj ;
            foreach (object o in InnerArray)
            {
                count++;
            }
        }

        public int Count() {
            
            return count;
        }
        public object this[int index]
        {
            get => InnerArray [index];     // Читання значення за індексом
            set => InnerArray[index] = value; // Запис значення за індексом
        }

        public void Add(object obj) 
        {
             object[] TempInnerArray = new object[count+1];
            for (int i = 0; i < count; i++)
            {
                TempInnerArray [i] = InnerArray[i];
            }
            TempInnerArray[count] = obj;
            //TempInnerArray[count]=obj;
            InnerArray = TempInnerArray;
            count++;


        }
        //public Kosharr(params object [] obj ) 
        //{
        //    foreach (object o in obj) 
        //    { 
        //    count++;
        //    }

        //   for (int i = 0; i < count; i++) 
        //    {
        //        InnerArray[i]=obj[i];
        //    }
        //}
        // object[] _innerArray = new object[count];



        //public int Count() {  return count ; }
        //return count > 0 ? count : 0; }

        // private object[] _innerArray = new object[1]; 
    }
}
