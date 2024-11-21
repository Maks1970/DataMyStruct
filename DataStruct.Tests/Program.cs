using DataStruct.Lib;

namespace DataStruct.Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int e = 2;
            // int[] mas = new int[3]; 
            int[] mas = new int[] { 1, 2, 3 };
            var d = new Kosharr(2,2,2);
            d[2] = 0;
            Console.WriteLine(Convert.ToString(d.Count()));
           
            //Kosharr d = new Kosharr(e);
        }
    }
}
