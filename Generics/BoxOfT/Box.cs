using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public Box()
        {
            Stack = new Stack<T>();
        }
        public Stack<T> Stack { get; set; }
        public int Count => Stack.Count;
        public void Add(T element)
        {
            Stack.Push(element);
        }
        public T Remove()
        {
            T element = Stack.Peek();
            Stack.Pop();
            return element;
        }
    }
}
