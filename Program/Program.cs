using DataStruct.Lib;
using System.Linq;


namespace DataStruct.Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ListKosh");
            var kosArr = new ListKosh(1, 2, 3, 4, 5);
            kosArr.Insert(1, 0);
            int countKosharr = kosArr.Count;
            kosArr.RemoveAt(4);
            bool remove = kosArr.Remove(3);
            var toArr = kosArr.ToArray();

            Console.WriteLine("LinkedList");

            var koshLinkedList = new LinkedList(1, 2, 3, 4);
            koshLinkedList.Insert(1, 0);
            koshLinkedList.Add(2);
            koshLinkedList.AddFirst(2);
            bool conkoshLinkedList = koshLinkedList.Contains(3);
            int count = koshLinkedList.Count;
            object koshLinkedListfirst = koshLinkedList.First;
            object koshLinkedListlast = koshLinkedList.Last;
            var toArrLinkedList = koshLinkedList.ToArray();
            koshLinkedList.Clear();

            Console.WriteLine("DoublylinkeList");

            var koshDoublyLinkedList = new DoublylinkeList(1, 2, 3, 4, 5);
            koshDoublyLinkedList.Insert(1, 0);
            koshDoublyLinkedList.Add(2);
            koshDoublyLinkedList.AddFirst(2);
            bool contkoshDoublyLinkedList = koshDoublyLinkedList.Contains(3);
            object koshDoublyLinkedListfirsy = koshDoublyLinkedList.First;
            object koshDoublyLinkedListLast = koshDoublyLinkedList.Last;
            var toArrkoshDoublyLinkedList = koshDoublyLinkedList.ToArray();
            koshDoublyLinkedList.Clear();

            Console.WriteLine("BinaryTreeNodeKosh");

            var koshBinaryTreeNodeKosh = new BinaryTreeNodeKosh(1, 4, 5, 6);
            koshBinaryTreeNodeKosh.Add(2);
            bool contBinaryTreeNodeKosh = koshBinaryTreeNodeKosh.Contains(4);
            var toArrkoshBinaryTreeNodeKosh = koshBinaryTreeNodeKosh.ToArray();
            int root = koshBinaryTreeNodeKosh.Count;
            int countKoshBinaryTreeNodeKosh = koshBinaryTreeNodeKosh.Root;
            koshBinaryTreeNodeKosh.Clear();
            Console.WriteLine("");
        }


    }
}
