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
            var d = new Kosharr(1, 3,2, 2,5, 4);
            //   d[2] = 0;
            // d.Add(1);
            // d.Insert(1, 5);
            //int [] array = d.ToArray();
            for (int i = 0; i < d._count; i++)
            {
                Console.Write($"{d[i]} ");
            }
            Console.WriteLine();
            // Console.WriteLine(Convert.ToString(d[1]));
          bool s=  d.Contains(9);
            int t = d.IndexOf(2);
            int j = 2;

            // d.Remove(1);
            d.Reverse();
            for (int i = 0; i < d._count; i++)
            {
                Console.Write($"{d[i]} ");
            }
            Console.WriteLine();
         //   d.RemoveAt(4);
            d.Reverse();
            for (int i = 0; i < d._count; i++)
            {
                Console.Write($"{d[i]} ");
            }
            //Kosharr d = new Kosharr(e);
        }
    }
}
