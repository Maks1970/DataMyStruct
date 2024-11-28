using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataStruct.Lib
{
    public class NodeDublyList:NodeLis
    {

        public NodeDublyList? Previous { get; set; }

        public NodeDublyList(object data) : base(data)
        {
            Previous = null;
        }

    }

    public class DoublylinkeList : LinkedKosh
    {
    
        public new int Count{ get; private set; }

        private NodeDublyList? tail;
        public DoublylinkeList() : base()
        {
            tail = null;
        }

        public DoublylinkeList(params object[] obj)
        {
            Count = 0;
            foreach (object o in obj)
            {
                Add(o);
            }
        }
        public DoublylinkeList(object obj)
        {
             Add(obj);
        }
        public new void Add(object obj)
        {
            NodeDublyList newNode = new NodeDublyList(obj);

            if (Head == null)  // Якщо список порожній
            {
                Head = newNode;  // новий елемент стає головним
                tail = newNode;
                First = newNode;// новий елемент також є хвостом
            }
            else
            {
                tail!.Next = newNode;  // вказуємо, що старий хвіст має наступний елемент
                newNode.Previous = tail;  // новий елемент має попередній вузол
                tail = newNode;  // оновлюємо хвіст
                Last = tail;
            }
            // Якщо поточний вузол є типом NodeDublyList, то додаємо попереднє посилання для нової ноди
            Count++;
        }

        public new void  AddFirst(object obj) 
        {
            NodeDublyList newNode = new NodeDublyList(obj);
            NodeDublyList newHead = (NodeDublyList)Head;

            if (Head != newNode)  // Якщо список порожній
            {
                newNode.Next = newHead;
                Head = newNode;
                tail = newNode;
                First = newNode;
            }
            else
            {
                tail!.Next = newNode;  // вказуємо, що старий хвіст має наступний елемент
                newNode.Previous = tail;  // новий елемент має попередній вузол
                tail = newNode;  // оновлюємо хвіст
                Last = tail;
            }
            // Якщо поточний вузол є типом NodeDublyList, то додаємо попереднє посилання для нової ноди
            Count++;
        }


        //public new bool Contains(object obj)
        //{
        //    int step = 0;
        //    //NodeDublyList removeNode = new NodeDublyList(obj);
        //    NodeDublyList current = (NodeDublyList)head;
        //    while (!current.Data.Equals(obj))
        //    {

        //        //Console.Write(current.Data + " ");
        //        current = (NodeDublyList)current.Next;
        //        step++;

        //    }
        //    if(step<Count) return true;

        //    return false;
        //}
        public  void Remove(object obj)
        {
            NodeDublyList? previous, next;
            NodeDublyList current = (NodeDublyList)Head;
            while (!current.Data.Equals(obj))
            {

                //Console.Write(current.Data + " ");
                current = (NodeDublyList)current.Next;
            }
            next = (NodeDublyList)current.Next;

            previous = current.Previous;
            previous!.Next= next;
            next.Previous = previous;
        }
        public void RemoveFirst()
        {
            First = Head.Next;
            Head = Head.Next;
            Count--;
        }

        public void RemoveLast()
        {
            if (tail == null)
            {
                return; // Список уже порожній, нічого видаляти
            }
            tail = tail.Previous;

         
            tail!.Next = null;
            Last =tail;
            Count--;
        }

        public void PrintList()
        {
            NodeDublyList current = (NodeDublyList)Head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = (NodeDublyList)current.Next;
            }
            Console.WriteLine();
        }
        

    }
}
