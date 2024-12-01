using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataStruct.Lib
{
    public class NodeDublyList:NodeList
    {
        public NodeDublyList? Previous { get; set; }
        public NodeDublyList(object data) : base(data)
        {
            Previous = null;
        }
    }

    public class DoublylinkeList : LinkedList
    {
        public object? First
        {
            get => Head?.Data;  // Повертає значення (Data) першої ноди, якщо вона є

        }

        private NodeDublyList? tail;

        public DoublylinkeList() : base()
        {
            tail = null;
        }
        public DoublylinkeList(params object[] item)
        {
            foreach (object o in item)
            {
                Add(o);
            }
        }

        public DoublylinkeList(object item)
        {
             Add(item);
        }

        public override void Add(object item)
        {
            NodeDublyList newNode = new NodeDublyList(item);

            if (Head == null)  // Якщо список порожній
            {
                Head = newNode;  // новий елемент стає головним
                tail = newNode;
               // First = newNode;// новий елемент також є хвостом
            }
            else
            {
                tail!.Next = newNode;  // вказуємо, що старий хвіст має наступний елемент
                newNode.Previous = tail;  // новий елемент має попередній вузол
                tail = newNode;  // оновлюємо хвіст
                Tail = tail;
            }
            // Якщо поточний вузол є типом NodeDublyList, то додаємо попереднє посилання для нової ноди
            Count++;
        }

        public override void  AddFirst(object item) 
        {
            NodeDublyList newNode = new NodeDublyList(item);
            NodeDublyList newHead = (NodeDublyList)Head;

            if (Head != newNode)  // Якщо список порожній
            {
                newNode.Next = newHead;
                Head = newNode;
                tail = newNode;
            }
            else
            {
                tail!.Next = newNode;  // вказуємо, що старий хвіст має наступний елемент
                newNode.Previous = tail;  // новий елемент має попередній вузол
                tail = newNode;  // оновлюємо хвіст
                Tail = tail;
            }
            // Якщо поточний вузол є типом NodeDublyList, то додаємо попереднє посилання для нової ноди
            Count++;
        }

        public  void Remove(object obj)
        {
            NodeDublyList? previous, next;
            NodeDublyList current = (NodeDublyList)Head;
            while (!current.Data.Equals(obj))
            {
                current = (NodeDublyList)current.Next;
            }
            next = (NodeDublyList)current.Next;

            previous = current.Previous;
            previous!.Next= next;
            next.Previous = previous;
        }

        public void RemoveFirst()
        {
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
            Tail =tail;
            Count--;
        }
    }
}
