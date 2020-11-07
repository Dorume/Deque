namespace Deque
{
    public class NodeStack
    {
        private Node head;
        private Node tail;
        public int Size { get; private set; }
        public bool IsEmpty => Size == 0;

        public void Push_front(int number)
        {
            Node node = new Node(number);
            if (IsEmpty)
            {
                head = node;
                head.Next = tail;
                tail = node;
                tail.Previous = head;
            }
            else
            {
                node.Next = head;
                head = node;
            }
            Size++;
        }

        public void Push_back(int number)
        {
            Node node = new Node(number);
            if(IsEmpty)
            {
                head = node;
                head.Next = tail;
                tail = node;
                tail.Previous = head;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
                tail = node;
            }
            Size++;
        }

        public int Pop_front()
        {
            Node temp = head;
            head = head.Next;
            Size--;
            return temp.Data;
        }

        public int Pop_back()
        {
            Node temp = tail;
            tail = tail.Previous;
            Size--;
            return temp.Data;
        }
        public int Front() => head.Data;
        public int Back() => tail.Data;
        public void Clear()
        {
            while (Size > 0)
                Pop_back();
        }

    }
}