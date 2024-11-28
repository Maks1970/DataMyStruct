using DataStruct.Lib;

namespace DataStruct.Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            BinaryTreeNodeKosh trea = new BinaryTreeNodeKosh(2,3,1,5);
        //    trea.Insert(4);
         
            //trea.Clear();
            //bool s = trea.Contains(3);
           var j=new Kosharr();
            var c = new Kosharr();
            
          
          // trea.PreOrderTraversal(j);
          int [] mas = new int[trea.count-1];
          //  mas = trea.ToArray();
            
            //   int e = 2;
            //   // int[] mas = new int[3]; 
            //   int[] mas = new int[] { 1, 2, 3 };
               var d = new Kosharr(1, 3,2, 2,5, 4);
            
            var b = new LinkedKosh(1, 3, 2, 6);
            var dou = new DoublylinkeList(1, 5, 6, 7,8,9,10,11);
            int linb=b.Count;
            int lindou1 = dou.Count;
            //dou.RemoveLast();
            //dou.RemoveFirst(); 
            //dou.Add(5);
            //dou.AddFirst(5);
           var getdou = dou.Get(3);
            int linc = b.Count;
            int lindou = dou.Count;
            var con = dou.Contains(10);
            var kk = dou.Last;
            object[] array = dou.ToArray();
            
           // b.Insert(1, 0);
           // b.Add(2);
            b.AddFirst(3);
           // var l = b.Last;
            bool f = b.Contains(0);
            for (int i = 0; i < b.Count; i++)
            {
                Console.Write($"{b.Get(i)} ");
            }
            Console.WriteLine();
            //   //   d[2] = 0;
            //   // d.Add(1);
            d.Insert(2, 5);
            //   //int [] array = d.ToArray();
            for (int i = 0; i < d.Count; i++)
            {
                Console.Write($"{d[i]} ");
            }
            Console.WriteLine();


            //   Console.WriteLine(Convert.ToString(j[1]));
            // bool s=  d.Contains(9);
            //   int t = d.IndexOf(2);
            //   int j = 2;

            //   // d.Remove(1);
            //   d.Reverse();
            for (int i = 0; i < j.Count; i++)
            {
                Console.Write($"{j[i]} ");
            }
            //   Console.WriteLine();
            ////   d.RemoveAt(4);
            //   d.Reverse();
            //   for (int i = 0; i < d._count; i++)
            //   {
            //       Console.Write($"{d[i]} ");
            //   }
            //Kosharr d = new Kosharr(e);
        }

      
    }
}
