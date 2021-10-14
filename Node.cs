using System;
using System.Collections.Generic;
using System.Text;

namespace Balance
{
    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

        public Node(T data)
        {
            this.Data = data;
            this.Next = null;
            this.Previous = null;
        }
    }
}
