using System;

namespace DataStructures
{
    class DoubleLinkedList<T>
    {
        //MEMBER VARIABLES
        NodeDouble<T> mHead;

        // CONSTRUCTORS
        public DoubleLinkedList() {}                        //default constructor

        public DoubleLinkedList(T[] arrayCopy)              //Param array constructor
        {
            for(int i = 0; i < arrayCopy.Length; i++)
            {
                Append(arrayCopy[i]);
            }
        }

        public void AddAtHead(T entry)
        {
            NodeDouble<T> newNode = new NodeDouble<T> ();       //a) create newNode - var type DoubleNode<T>        - new memory block
            newNode.mData = entry;                                  //set mData

            newNode.mNext = mHead;                              //b) set newNode.mNext              -> set to current mHead
            mHead.mPrevious = newNode;                          //c) set current mHead.previous     -> set to newNode
            mHead = newNode;                                    //d) set LL mHead                   -> set to newNode
        }

        
        public void Append(T entry)                     // Appends entry to end of list.
        {
            NodeDouble<T> newNode = new NodeDouble<T>();        //a) create newNode - var type nodeDouble<T>           - new memory block
            newNode.mData = entry;                              //  & set mData

            if(mHead == null)                                   //b) SIZE CHECK     -   LL empty
            {
                mHead = newNode;
                return;
            }
                                                                //c) ITERATOR FIND LAST - mNext !=null - while loop
            NodeDouble<T> iterator = mHead;                         //c1) create iterator - var type nodeDouble<T>      -> set to mhead
            while(iterator.mNext != null)                           //c2) while loop - iterate until mNext is null (end of list)
            {
                iterator = iterator.mNext;
            }
            iterator.mNext = newNode;                           //d) set iterator.mNext             -> set to newNode
            newNode.mPrevious = iterator;                       //e) set newNode.mPrevious          -> set to iterator

        }

        
        public void Insert(T entry, int index)      // Insert entry at supplied index, throws an exception on failure
        {
            NodeDouble<T> newNode = new NodeDouble<T>();        //a) create newNode
            newNode.mData = entry;                              //  & set mData

            if(index > Size() || index < 0)                     //b) ERROR CHECK    -   Index out of Range      -   index less than 0
            {
                throw new ArgumentOutOfRangeException("index out of range or less than 0 in DoubleLinkList Insert.");
            }
            if(index == 0)                                      //c) SIZE CHECK     -   Index is 0 (add to head)
            {
                newNode.mNext = mHead;                              //c1) set newNode.mNext              -> set to current mHead
                mHead.mPrevious = newNode;                          //c2) set current mHead.previous     -> set to newNode
                mHead = newNode;                                    //c3) set LL mHead                   -> set to newNode
            }
                                                                //d) ITERATOR REMOVE/INSERT - find node at Index-1     - for loop
            NodeDouble<T> iterator = mHead;                         //d1) create iterator
            for(int i = 0; i < index-1; i++)                        //d2) For loop -iterate until index-1 (INSERT/REMOVE) 
            {
                iterator = iterator.mNext;
            }
            newNode.mNext = iterator.mNext;                     //e) set newNode.mNext                  -> set to iterator.mNext
            iterator.mNext = newNode;                           //f) set iterator.mNext                 -> set to newNode                 
            newNode.mPrevious = iterator;                       //g) set newNode.mPrevious              -> set to iterator          **unique step**
        }

        // Remove entry at supplied index, throws an exception on failure
        public void Remove(int index) {}

        // Set entry to list entry at supplied index, throws an exception on failure
        public void Replace(T entry, int index) {}

        
        public T Get(int index)                     // Returns the data contained at the provided index, throws an exception on failure 
        {
            if(index > Size() || index <0)                      //a) ERROR CHECK    -   index in range      -   index less than 0
            {
                throw new ArgumentOutOfRangeException("index out of range or less than zero in Get function within DoubleLinkedList");
            }
                                                                //b) ITERATOR GET/REPLACE VAR - find node at INDEX - FOR loop
            NodeDouble<T> iterator = mHead;                         //b1) create iterator
            for(int i = 0; i < index; i++)                          //b2) for loop - iterate until index (GET VAR)
            {
                iterator = iterator.mNext;
            }
            
            return iterator.mData;                                  //c) return mData of iterator. 
        }

        // Return index of first instance of supplied entry or -1 if not found.
        public int Find(T entry) { return -1; }

        
        public int Size()                           // Return current size of list.
        {
            int listSize = 0;                           //a) create indexCount var
            if(mHead ==null)                            //b) SIZE CHECK         -   LL empty
            {
                return listSize;
            }
            listSize++;                                 //c) incrument listSize+1   (accounts for mHead)
            
                                                        //d) ITERATOR FIND END - mNext !=null - while loop
            NodeDouble<T> iterator = mHead;                 //d1) creeat iterator 
            while(iterator.mNext != null)                   //d2) while loop - iterate until mNext=null
            {
                iterator = iterator.mNext;
                listSize++;                                 //d3) incremnet listSize+1
            }
            return listSize; 
        }

        // Prints the list
        public void Print() { }
    }
}
