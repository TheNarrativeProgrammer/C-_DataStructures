using System;

namespace DataStructures
{
    class Queue<T>
    {
        //MEMBER VARIABLES
        Node<T> mFront;
        Node<T> mRear;

        // CONSTRUCTORS
        public Queue() {}

        
        public void Enqueue(T entry)                // Adds an entry to the rear of the queue
        {
            Node<T> newNode = new Node<T>();                //a) create newNode - var of type Node<T>                   - new memory block
            newNode.mData = entry;                          // & set mData of newNode to param "entry"

                                                            //b) SIZE CHECK    -   LL empty (check mRear)
            if(mRear == null)
            {
                mFront = newNode;                                //Set mFront & mRear to newNode if empty
                mRear = newNode;
                return;
            }
                                                            //c) ITERATOR FIND LAST NODE - mNext != null - WHILE LOOP
            Node<T> iterator = mFront;                           //c1) create iterator - var of type Node<T>                 -> set to mHead
            while(iterator.mNext != null)                       //c2) while loop - iterate until mNext is null (end of list)
            {
                iterator = iterator.mNext;
            }
            iterator.mNext = newNode;                       //ds) set mNext of iterator to newNode - new node now last node
            mRear = newNode;                                                                                                //*****unique step*******
        }

        
        public T Dequeue()                          // Remove and returns the element at the front of the queue
        {
            if(mRear == null)
            {
                throw new InvalidOperationException("Quene is empty. Can't remove anything.");
            }
            Node<T> currentFront = mFront;
            mFront = mFront.mNext;
            if(mFront == null)
            {
                mRear = null;
            }
            return currentFront.mData;

        }

        
        public int Size()                           // Return current size of queue.
        {
            int listSize = 0;                               //a) create local "listSize" var set to 0
                                                            //b) ERROR CHECK    -   LL is empty
            if (mRear == null)                               // if LL is empty - return 0
            {
                return 0;
            }
            listSize++;                                     //c) increase "listSize" by 1      -   iterator handles iteration above size of 1. This accounts for Node at mHead.

                                                            //d) ITERATOR FIND LAST NODE - mNext != null - WHILE LOOP
            Node<T> iterator = mFront;                           //d1) create iterator - var of type Node<T> - set to mHead
            while (iterator.mNext != null)                      //d2) while loop - iterate until iterator.mNext is null (end of list)
            {
                iterator = iterator.mNext;                      //set iterator to iterator.mNext (next node in list to check)
                listSize++;                                        //update listSize count +1
            }
            return listSize;
        }

        //Returns true if there's nothing in the queue
        public bool IsEmpty()
        {
            return mRear == null;
        }
    }
}
