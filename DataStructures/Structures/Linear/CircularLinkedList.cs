using System;

namespace DataStructures
{
    class CircularLinkedList<T>
    {
        //MEMBER VARIABLES
        NodeDouble<T> mHead;
        NodeDouble<T> mTail;

        // CONSTRUCTORS
        public CircularLinkedList() {}      //Default


        //public void AddToHead(T entry)
        //{
        //    NodeDouble<T> newNode = new NodeDouble<T> ();
        //    newNode.mData = entry;

        //    newNode.mNext = mHead;                              //b) set newNode.mNext              -> set to current mHead
        //    mHead.mPrevious = newNode;                          //c) set current mHead.previous     -> set to newNode
        //    mHead = newNode;                                    //d) set LL mHead                   -> set to newNode

        //    if(mTail==null)
        //    {
        //        mTail = newNode;
        //    }
        //    mTail.mNext = mHead;

        //}
        
        public void Append(T entry)                         // Appends entry to end of list.
        {
            NodeDouble<T> newNode = new NodeDouble<T>();        //a) create newNode - var type nodeDouble<T>           - new memory block
            newNode.mData = entry;                              //  & set mData

            if(mHead == null)                                   //b) SIZE CHECK     -   LL empty
            {
                mHead = newNode;
                mTail = newNode;
                mTail.mNext = mHead;
                return;
            }
                                                                //c) ITERATOR FIND LAST - mNext !=null - while loop
            NodeDouble<T> iterator = mHead;                         //c1) create iterator - var type nodeDouble<T>      -> set to mhead
            while(iterator.mNext != mHead)                           //c2) while loop - iterate until mNext is null (end of list)
            {
                iterator = iterator.mNext;
            }
            iterator.mNext = newNode;                           //d) set iterator.mNext             -> set to newNode
            newNode.mPrevious = iterator;                       //e) set newNode.mPrevious          -> set to iterator                  *****unique step*******
            newNode.mNext = mHead;                              //e) set newNode.mPrevious          -> set to iterator                      ***unique step - Circle ****
            mTail = newNode;
        }

        
        public void Insert(T entry, int index)              // Insert entry at supplied index, throws an exception on failure
        {
            NodeDouble<T> newNode = new NodeDouble<T>();        //a) create newNode
            newNode.mData = entry;                              //  & set mData

            if (index > Size() || index < 0)                     //b) ERROR CHECK    -   Index out of Range      -   index less than 0
            {
                throw new ArgumentOutOfRangeException("index out of range or less than 0 in DoubleLinkList Insert.");
            }
            if (index == 0)                                      //c) SIZE CHECK     -   Index is 0 (add to head)
            {
                newNode.mNext = mHead;                              //c1) set newNode.mNext              -> set to current mHead
                mHead.mPrevious = newNode;                          //c2) set current mHead.previous     -> set to newNode
                mHead = newNode;                                    //c3) set LL mHead                   -> set to newNode
                //mTail = mHead;                                      //c4) set mTail                      -> set to mHead                        ***unique step - Circle ****
                mTail.mNext = mHead;
            }
                                                                //d) ITERATOR INSERT/REMOVE NODE    -   find node at Index-1     -  for loop
            NodeDouble<T> iterator = mHead;                         //d1) create iterator
            for (int i = 0; i < index - 1; i++)                        //d2) For loop -iterate until index-1 (INSERT/REMOVE) 
            {
                iterator = iterator.mNext;
            }
            newNode.mNext = iterator.mNext;                     //e) set newNode.mNext                      -> set to iterator.mNext
            iterator.mNext = newNode;                           //f) set iterator.mNext                     -> set to newNode                 
            newNode.mPrevious = iterator;                       //g) set newNode.mPrevious                  -> set to iterator          *****unique step*******
        }

        
        public void Remove(int index)                   // Remove entry at supplied index, throws an exception on failure
        {
            if (index > Size() || index < 0)                     //a) ERROR CHECK    -   index out range     -    index less than 0
            {
                throw new ArgumentOutOfRangeException("index out of range or less than one in Remove function of DoubleLinked List.");
            }
            if (mHead == null)                                      //a1) ERROR CHECK    -   LL empty
            {
                throw new Exception("Link list is empty. Can't use Remove function in DoubleLinkedList Class");
            }
            if (index == 0)                                     //b) SIZE/INDEX CHECK   -   index 0 (remove @head)      -   LL not empty
            {
                NodeDouble<T> currentHead = mHead;                  //b1) create currentHead                -> set to  mHead                -   store current mhead
                if(mHead == mTail)
                {
                    mHead = null;
                    mTail = null;
                }
                else
                {
                    mHead = mHead.mNext;                                //b2) move LL mHead down line           -> set to mHead.mNext           -   move mHead to next Node (mHead.mNext)
                    mHead.mPrevious = null;                             //b4) de-ref mHead.Previous             -> set to null                  -   NOTE: Pedro, is this step necessary?
                    mTail.mNext = mHead;                                //b5) set mTail.mNext                   -> set to mHead                 *****circle - unique step*******

                }                                                       //DE-REF CURRENT HEAD                                                    *****circle - unique step & different order*******
                currentHead.mNext = null;                               //b3) de-ref currentHead                -> set to null                  -   removes ref to currentHead
                currentHead.mPrevious = null;
                currentHead = null;
                return;
            }
            //c) ITERATOR INSERT/REMOVE NODE    -   find node at Index-1     -  for loop
            NodeDouble<T> iterator = mHead;                         //c1) create iterator
            for (int i = 0; i < index - 1; i++)                        //c2) for loop  - iterate until index-1 (INSERT/REMOVE)  
            {
                iterator = iterator.mNext;
            }
            NodeDouble<T> nodeToDelete = iterator.mNext;        //d) create nodeToDelete                    -> set to iterator.mNext
            iterator.mNext = nodeToDelete.mNext;                //e) move iterator.mNext down LL line       -> set to nodeToDelete.mNext
            nodeToDelete.mNext.mPrevious = iterator;            //f) move Node2D.mNext.mPrevious down line  -> set to iterator          *****unique step*******           
            nodeToDelete.mNext = null;                          //g) de-ref nodeToDelet.mNext               -> set to null
            nodeToDelete.mPrevious = null;                      //h) de-ref nodeToDelet.mPrevious           -> set to null              *****unique step*******

            if(nodeToDelete ==mTail)
            {
                mTail = iterator;
            }
        }

        
        public void Replace(T entry, int index)         // Set entry to list entry at supplied index, throws an exception on failure
        {
            if(index > Size()|| index < 0)                  //a) ERRROR CHECK   -   index of out range      -   index less than 0
            {
                throw new ArgumentOutOfRangeException("index is greater than link list size or less than 0.");
            }
            if(index == 0)                                  //b) SIZE CHECK       -   index 0 (replace mData @head)  
            {
                mHead.mData = entry;
            }
                                                            //c) ITERATOR GET/REPLACE VAR  - find node at INDEX - FOR loop
            NodeDouble<T> iterator = mHead;                           //c1) create iterator  - var type Node<T>                   -> set to mHead
            for(int i = 0; i < index; i++)
            {
                iterator = iterator.mNext;
            }
            iterator.mData = entry;                         //d) set mData to entry
        }

        
        public T Get(int index)                         // Returns the data contained at the provided index, throws an exception on failure            
        {
            if (index > Size() || index < 0)                    //a) ERROR CHECK    -   index in range      -   index less than 0
            {
                throw new ArgumentOutOfRangeException("index out of range or less than zero in Get function within DoubleLinkedList");
            }
                                                                //b) ITERATOR GET/REPLACE VAR - find node at INDEX - FOR loop
            NodeDouble<T> iterator = mHead;                         //b1) create iterator
            for (int i = 0; i < index; i++)                          //b2) for loop - iterate until index (GET VAR)
            {
                iterator = iterator.mNext;
            }

            return iterator.mData;                              //c) return mData of iterator.
        }

        
        public int Find(T entry)                    // Return index of first instance of supplied entry or -1 if not found.
        {
            bool hasFoundData = false;                          //a) create hasFound                -       for case when no mData matches entry searched
            int indexCount = 0;                                     //a1) create indexCount         -       iteration count
            int indexOfFirstMatch = 0;                              //a2) create indexOfFirstMatch  -       stores index of match

                                                                //b) ITERATOR FIND LAST NODE - mNext != null - WHILE LOOP
            NodeDouble<T> iterator = mHead;                         //b1) create iterator - var of type Node<T> -> set to mHead
            while(iterator.mNext != mHead)                           //b2) while loop - iterate until mNext is null (end of LL)         *****Circle - unique step*******
            {
                
                if(iterator.mData.Equals(entry))                    //b3) check if mData = entry        note: use "equals" function not "=" operator
                {
                    indexOfFirstMatch = indexCount;
                    hasFoundData = true;
                    break;
                }
                iterator = iterator.mNext;                          //b4) incument iterator and indexCount
                indexCount++;
            }

            if(hasFoundData==false)                             //c) check if match was found -> set indexOfFirstMatch to -1 if false
            {
                indexOfFirstMatch = -1;
            }
            return indexOfFirstMatch; 
        }

        // Return current size of list.
        public int Size()
        {
            int listSize = 0;                           //a) create indexCount var
            if (mHead == null)                          //b) SIZE CHECK         -   LL empty
            {
                return listSize;
            }
            listSize++;                                 //c) incrument listSize+1   (accounts for mHead)

                                                        //d) ITERATOR FIND END - mNext !=null - while loop
            NodeDouble<T> iterator = mHead;                 //d1) creeat iterator 
            while (iterator.mNext != mHead)                  //d2) while loop - iterate until mNext=mHead                           *****unique step*******
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
