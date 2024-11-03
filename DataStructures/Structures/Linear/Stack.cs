using System;

namespace DataStructures
{
    class Stack<T>
    {

        // Constructor
        public Stack() {}

        // Adds an entry to the top of the stack
        public void Push(T entry) {}

        // Remove and returns the element at the top of the stack
        public T Pop() { return (T)Activator.CreateInstance(typeof(T)); }

        // Returns the element at the top of the Stack without removing it
        public T Peek() { return (T)Activator.CreateInstance(typeof(T)); }

        // Return current size of stack.
        public int Size() { return -1; }

        //Returns true if there's nothing in the stack
        public bool IsEmpty() { return false; }
    }
}

