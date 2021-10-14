using System;
using System.Collections.Generic;
using System.Text;

namespace Balance
{
    class Stack<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public Node<T> Current { get; set; }
        public int Size { get; set; }

        public Stack()
        {
            Head = null;
            Tail = null;
            Size = 0;
        }

        public bool IsEmpty()
        {
            if (Size == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public T Peek()
        {
            return Tail.Data;
        }

        public T Pop()
        {
            T data = Peek(); //save current tail

            Tail = Tail.Previous;

            Size--;

            return data;
        }

        public void Push(T data)
        {
            Node<T> node = new Node<T>(data);
            if (IsEmpty())
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node; // current next = new node
                node.Previous = Tail; // new node previous  = tail
                Tail = node; // tail = new node
            }
            Size++;
        }
    }
}
