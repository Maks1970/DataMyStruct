using System.Reflection.Metadata.Ecma335;

namespace DataStruct.Lib
{
    public class Kosharr
    {
        //  List<int> df ;
        private int count = 0 ;
        public Kosharr(params object [] obj ) 
        {
            foreach (object o in obj) 
            { 
            count++;
            }
            object[] _innerArray = new object[count];
        }
        public int Count() { return count ; }
                             //return count > 0 ? count : 0; }

       // private object[] _innerArray = new object[1]; 
    }
}
