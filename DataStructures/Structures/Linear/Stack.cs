using System;

namespace DataStructures
{
    class Stack<T>
    {
        //MEMBER VARIABLES
        Node<T> mHead;

        // Constructor
        public Stack() {}

        
        public void Push(T entry)               // Adds an entry to the top of the stack
        {
            Node<T> newNode = new Node<T>();                //a) create newNode - var of type Node<T>                   - new memory block
            newNode.mData = entry;                          // & set mData of newNode to param "entry"

            newNode.mNext = mHead;                          //b) set newNode.mNext                  -> set to mHead
            mHead = newNode;                                //c) set LL mHead                       -> set to newNode
        }

        
        public T Pop()                          // Remove and returns the element at the top of the stack
        {
            if (mHead == null)                               //a) ERROR CHECK - LL is empty
            {
                throw new InvalidOperationException("Link list is empty. Can't remove from empty list");
            }
            Node<T> currentHead = mHead;                    //b1) create currentHead                -> set to  mHead                -   store current mhead
            mHead = mHead.mNext;                            //b2) update LL mHead                    -> set to mHead.mNext           -   move mHead to next Node (mHead.mNext)
            //currentHead has nothing pointing at it        //b3) de-ref currentHead                -> set to null                  -   removes ref to currentHead
            
            return currentHead.mData;
        }

        
        public T Peek()                     // Returns the element at the top of the Stack without removing it
        {
            if (mHead == null)                               //a) ERROR CHECK - LL is empty
            {
                throw new InvalidOperationException("Link list is empty. Can't remove from empty list");
            }

            return mHead.mData;
        }

        
        public int Size()                       // Return current size of stack.
        {
            int listSize = 0;                               //a) create local "listSize" var set to 0
                                                            //b) ERROR CHECK    -   LL is empty
            if (mHead == null)                               // if LL is empty - return 0
            {
                return 0;
            }
            listSize++;                                     //c) increase "listSize" by 1      -   iterator handles iteration above size of 1. This accounts for Node at mHead.

                                                            //d) ITERATOR FIND LAST NODE - mNext != null - WHILE LOOP
            Node<T> iterator = mHead;                           //d1) create iterator - var of type Node<T> - set to mHead
            while (iterator.mNext != null)                      //d2) while loop - iterate until iterator.mNext is null (end of list)
            {
                iterator = iterator.mNext;                      //set iterator to iterator.mNext (next node in list to check)
                listSize++;                                        //update listSize count +1
            }
            return listSize;
        }

        
        public bool IsEmpty()                   //Returns true if there's nothing in the stack
        {
            return mHead == null;
        }
    }
}

