using DataStruct.Lib;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;


namespace DataStruct.Tests
{
    public class Program
    {
        public static void MyHandle<T>(object? sender, CollectionChanged<T> e)
        {
            Console.WriteLine($"Дiя: {e.Change}, Елемент: {e.Item}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("MyObservableList");
            var ObservableList = new MyObservableList<int>(1, 2, 3, 4, 5);
            ObservableList.OnChange += MyHandle;
            //    (sender, e) =>
            //{ 
            //    Console.WriteLine($"Дiя: {e.Change}, Елемент: {e.Item}"); 
            //};
            ObservableList.Add(2);
            ObservableList.Insert(3,1);
            ObservableList.Remove(2);
            ObservableList.RemoveAt(3);
            //int d =ObservableList[2];
            //foreach (var item in ObservableList) 
            //{
            //    Console.Write(item+" "); 
            //}
            Console.WriteLine();
            var arr = ObservableList.ToArray();
            ObservableList.OnChange -= MyHandle!;

            Console.WriteLine("ListKosh");
            var kosArr = new ListKosh<int>(2,2,2);

            IEnumerator<int> iterList = kosArr.GetEnumerator();
            iterList = new ToArrayM<int>(iterList);
            ///////
            var larr = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerator<int> enumar=larr.GetEnumerator();
            enumar = new ToArrayM<int>(enumar);
            while (enumar.MoveNext())
            {
                Console.WriteLine(enumar.Current); // Виведе елементи масиву
            }
            //////////

            var list = new ListKosh<int> { 1, 2, 3, 4, 5 };
            var enumerator = list.GetEnumerator(); // Створення Enumerator для списку
            iterList = new ToListM<int>(enumerator);
            //iterList = toListM;

            ////arr
            ////var dd  = new ToArrayM<int>(iterList);
            //IEnumerator<int> enumerator = kosArr.GetEnumerator();

            //// Створюємо екземпляр ToArrayM з переданим enumerator
            //ToArrayM<int> toArrayM = new ToArrayM<int>(enumerator);

            //// Виводимо всі елементи за допомогою ToArray
            //int[] array = toArrayM.ToArray();
            ////arr
            //IEnumerator<bool> iterrList = new AllM<int>(kosArr.GetEnumerator(), x => x % 5 == 0);
            // IEnumerable<int> itderList = new TakeM<int>(kosArr,2);
            //double firstGreaterThanTen = iterList.Current;
            while (iterList.MoveNext())
            {
                //d = iterrList.Current;
                Console.Write(iterList.Current + " ");
                
            }
            Console.WriteLine();
            IEnumerator<int> iterSkipList = kosArr.GetEnumerator();
            iterSkipList = new SkipWhileM<int>(iterSkipList, skip => skip > 3);
            while (iterSkipList.MoveNext())
            {
                Console.Write(iterSkipList.Current + " ");
            }

            foreach (var item in kosArr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            
            //var buf = kosArr.TakeM(3);
            //foreach (var item in kosArr.Skip( num=>num<4))
            //{
            //    Console.Write(item + " ");
            //}
            Console.WriteLine();
            //IEnumerator<int> iter = kosArr.GetEnumerator();
            //while (iter.MoveNext())
            //{
            //    Console.WriteLine(iter.Current);
            //}
            kosArr.Insert(1, 0);
            var countKosharr = kosArr.Count;
            kosArr.RemoveAt(4);
            bool remove = kosArr.Remove(3);
            var toArr = kosArr.ToArray();

            Console.WriteLine("LinkedList");

            var koshLinkedList = new LinkedListKosh<int>(1, 2, 3, 4, 5);
            foreach (var item in koshLinkedList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
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
            foreach (var item in koshDoublyLinkedList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            koshDoublyLinkedList.Add(2);
            koshDoublyLinkedList.AddFirst(2);
            bool contkoshDoublyLinkedList = koshDoublyLinkedList.Contains(3);
            object koshDoublyLinkedListfirsy = koshDoublyLinkedList.First;
            object koshDoublyLinkedListLast = koshDoublyLinkedList.Last;
            var toArrkoshDoublyLinkedList = koshDoublyLinkedList.ToArray();
            koshDoublyLinkedList.Clear();

            Console.WriteLine("BinaryTreeNodeKosh");

            var koshBinaryTreeNodeKosh = new BinaryTreeNodeKosh<int>(10, 9, 11, 12, 7);
            foreach (var item in koshBinaryTreeNodeKosh)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
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
