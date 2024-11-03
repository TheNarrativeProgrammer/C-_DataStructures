using System;

namespace DataStructures
{
    public class SingleLinkedList<T>
    {

        // Constructor
        public SingleLinkedList() { }

        // Constructor that populates the list with the contesnt of an array
        public SingleLinkedList(T[] arrayCopy) { }

        // Appends entry to end of list.
        public void Append(T entry) { }

        // Insert entry at supplied index
        public void Insert(T entry, int index) {}

        // Remove entry at supplied index
        public void Remove(int index) {}

        // Set entry to list entry at supplied index
        public void Replace(T entry, int index) {}

        // Returns the data contained at the provided index
        public T Get(int index) { return (T)Activator.CreateInstance(typeof(T)); }

        // Return index of first instance of supplied entry or -1 if not found.
        public int Find(T entry) { return -1; }

        // Return current size of list.
        public int Size() { return -1; }

        // Prints all elements of the list to the screen
        public void Print() { }
    }
}
