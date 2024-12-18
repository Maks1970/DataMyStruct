using DataStruct.Lib;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;


namespace DataStruct.Tests
{
    public class Program
    {
      
        static void Main(string[] args)
        {
            Console.WriteLine("MyObservableList");
            var ObservableList = new MyObservableList<int>(1, 2, 3, 4, 5);
            ObservableList.OnChange += ObservableList.MyHandle;
            //    (sender, e) =>
            //{ 
            //    Console.WriteLine($"Дiя: {e.Change}, Елемент: {e.Item}"); 
            //};
            ObservableList.Add(2);
            ObservableList.Insert(3,1);
            ObservableList.Remove(2);
            ObservableList.RemoveAt(3);
            var arr = ObservableList.ToArray();
           

            Console.WriteLine("ListKosh");
            var kosArr = new ListKosh<int>(1, 2, 3, 4, 5);
            kosArr.Insert(1, 0);
            var countKosharr = kosArr.Count;
            kosArr.RemoveAt(4);
            bool remove = kosArr.Remove(3);
            var toArr = kosArr.ToArray();

            Console.WriteLine("LinkedList");

            var koshLinkedList = new LinkedListKosh<int>(1, 2, 3, 4);
            koshLinkedList.Insert(1, 0);
            koshLinkedList.Add(2);
            koshLinkedList.AddFirst(2);
            bool conkoshLinkedList = koshLinkedList.Contains(3);
            var count = koshLinkedList.Count;
            object koshLinkedListfirst = koshLinkedList.First;
            object koshLinkedListlast = koshLinkedList.Last;
            var toArrLinkedList = koshLinkedList.ToArray();
            koshLinkedList.Clear();

            Console.WriteLine("DoublylinkeList");

            var koshDoublyLinkedList = new DoublylinkeList<int>(1, 2, 3, 4, 5);
            koshDoublyLinkedList.Add(2);
            koshDoublyLinkedList.AddFirst(2);
            bool contkoshDoublyLinkedList = koshDoublyLinkedList.Contains(3);
            object koshDoublyLinkedListfirsy = koshDoublyLinkedList.First;
            object koshDoublyLinkedListLast = koshDoublyLinkedList.Last;
            var toArrkoshDoublyLinkedList = koshDoublyLinkedList.ToArray();
            koshDoublyLinkedList.Clear();

            Console.WriteLine("BinaryTreeNodeKosh");

            var koshBinaryTreeNodeKosh = new BinaryTreeNodeKosh<int>(5, 3, 4, 6);
            koshBinaryTreeNodeKosh.Add(2);
            bool contBinaryTreeNodeKosh = koshBinaryTreeNodeKosh.Contains(4);
            var toArrkoshBinaryTreeNodeKosh = koshBinaryTreeNodeKosh.ToArray();
            int root = koshBinaryTreeNodeKosh.Count;
            int countKoshBinaryTreeNodeKosh = koshBinaryTreeNodeKosh.Root;
            koshBinaryTreeNodeKosh.Clear();
            Console.WriteLine("");
            ObservableList.OnChange -= ObservableList.MyHandle!;
        }


    }
}
