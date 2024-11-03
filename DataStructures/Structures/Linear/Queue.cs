using System;

namespace DataStructures
{
    class Queue<T>
    {
        // Constructor
        public Queue() {}

        // Adds an entry to the rear of the queue
        public void Enqueue(T entry) {}

        // Remove and returns the element at the front of the queue
        public T Dequeue() { return (T)Activator.CreateInstance(typeof(T)); }

        // Return current size of queue.
        public int Size() { return -1; }

        //Returns true if there's nothing in the queue
        public bool IsEmpty() { return false; }
    }
}
