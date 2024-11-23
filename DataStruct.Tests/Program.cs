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
            var d = new Kosharr(1, 3, 2, 2,2,2, 4);
            //   d[2] = 0;
            // d.Add(1);
            // d.Insert(1, 5);
            for (int i = 0; i < d.count; i++)
            {
                Console.Write($"{d[i]} ");
            }
            Console.WriteLine();
            // Console.WriteLine(Convert.ToString(d[1]));
            int j = 2;
            d.Remove(j);
            for (int i = 0; i < d.count; i++)
            {
                Console.Write($"{d[i]} ");
            }
            //Kosharr d = new Kosharr(e);
        }
    }
}
