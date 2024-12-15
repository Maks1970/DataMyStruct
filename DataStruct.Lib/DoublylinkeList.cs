using Interfaces_List;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataStruct.Lib
{
    public class NodeDublyList<T> : NodeList<T>, IDoublyLinkedNode<T>
    {
        public IDoublyLinkedNode<T>? Previous { get; set; }
        public NodeDublyList(T data) : base(data)
        {
            Previous = null;
        }
    }

    public class DoublylinkeList<T> : LinkedListKosh<T>, IDoublyLinkedList<T>
    {
        public T? First
        {
            get => Head.Data;  // Повертає значення (Data) першої ноди, якщо вона є

        }

        private IDoublyLinkedNode<T>? tail;

        public DoublylinkeList() : base()
        {
            tail = null;
        }
        public DoublylinkeList(params T[] item)
        {
            foreach (T o in item)
            {
                Add(o);
            }
        }

        public DoublylinkeList(T item)
        {
             Add(item);
        }

        public override void Add(T item)
        {
            NodeDublyList<T> newNode = new NodeDublyList<T>(item);

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

        public override void  AddFirst(T item) 
        {
            NodeDublyList<T> newNode = new NodeDublyList<T>(item);
            NodeDublyList<T> newHead = (NodeDublyList<T>)Head;

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

        public  void Remove(T obj)
        {
            IDoublyLinkedNode<T>? previous, next;
            IDoublyLinkedNode<T> current = (NodeDublyList<T>)Head;
            while (!current.Data.Equals(obj))
            {
                current = (NodeDublyList<T>)current.Next;
            }
            next = (NodeDublyList<T>)current.Next;

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
