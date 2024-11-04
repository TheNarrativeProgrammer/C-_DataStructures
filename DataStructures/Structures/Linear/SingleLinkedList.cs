using System;
using System.Xml;

namespace DataStructures
{
    public class SingleLinkedList<T>
    {
        //MEMBER VARIABLES
        public Node<T> mHead;
        public int mSize;

        // CONSTRUCTORS 
        public SingleLinkedList()                   //deafult constructor
        {
        }               

        public SingleLinkedList(T[] arrayCopy) 
        {
            for(int i = 0; i < arrayCopy.Length; i++)
            {
               
            }
        } 

        
        public void Append(T entry)                 // Appends entry to end of list.
        {
            Node<T> newNode = new Node<T>();            //a) create newNode - var of type Node<T> - new memory block
            newNode.mData = entry;                      // & set mData of newNode to param "entry"

            newNode.mNext = mHead;                      //b) set mNext of newNode to current mHead
            mHead = newNode;                            //c) set mHead of LL to newNode 
        }

       
        public void Insert(T entry, int index)       // Insert entry at supplied index
        {
            Node<T> newNode = new Node<T>();            //a) create newNode - var of type Node<T> - new memory block
            newNode.mData = entry;                      //& set mData of newNode to param "entry"

                                                        //b) Error Check - index in range, LL empty, inserting @ index 0 

            int listSize = Size();                          //b1) create listSize var - get LL size. 
            if(index > listSize)                            //b2) check if param "index" is outside range of listSize
            {
                throw new ArgumentOutOfRangeException("index outside range in Insert function");
                return;
            }
            if(listSize==0 || index==0)                     //b3) check if LL is empty or if index param is 0 - set newNode to mHead if true
            {
                newNode.mNext = mHead;                          //set mNext of newNode to mHead.        Note: mHead=null if list is empty and newNode.mNext=null b/c it's 1st and last node
                mHead=newNode;                                  //set mHead to newNode
                return;

            }


        }

        // Remove entry at supplied index
        public void Remove(int index) {}

        // Set entry to list entry at supplied index
        public void Replace(T entry, int index) {}

        // Returns the data contained at the provided index
        public T Get(int index) { return (T)Activator.CreateInstance(typeof(T)); }

        // Return index of first instance of supplied entry or -1 if not found.
        public int Find(T entry) { return -1; }

        // Return current size of list.
        public int Size()
        {
            int index = 0;                              //a) create local "index" var set to 0
            if(mHead == null)                           //b) check if LL is empty
            {
                return 0;
            }
                                                        //c) iterator
            Node<T> iterator = mHead;                       //create iterator - var of type Node<T> - set to mHead
            while (iterator.mNext != null)                  //while loop - iterate until iterator.mNext is null (end of list)
            {
                iterator = iterator.mNext;                  //set iterator to iterator.mNext (next node in list to check)
                index++;                                    //update index count +1
            }                                               
            return index; 
        }

        // Prints all elements of the list to the screen
        public void Print() { }
    }
}
