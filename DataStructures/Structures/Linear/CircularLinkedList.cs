using System;

namespace DataStructures
{
    class CircularLinkedList<T>
    {
        // Constructor
        public CircularLinkedList() {}

        // Appends entry to end of list.
        public void Append(T entry) {}

        // Insert entry at supplied index, throws an exception on failure
        public void Insert(T entry, int index) {}

        // Remove entry at supplied index, throws an exception on failure
        public void Remove(int index) {}

        // Set entry to list entry at supplied index, throws an exception on failure
        public void Replace(T entry, int index) {}

        // Returns the data contained at the provided index, throws an exception on failure
        public T Get(int index) { return (T)Activator.CreateInstance(typeof(T)); }

        // Return index of first instance of supplied entry or -1 if not found.
        public int Find(T entry) { return -1; }

        // Return current size of list.
        public int Size() { return -1; }

        // Prints the list
        public void Print() { }
    }
}
