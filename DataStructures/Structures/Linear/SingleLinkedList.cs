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

        
        public void AddtoHead(T entry)                 // Add entry to START of list.
        {
            Node<T> newNode = new Node<T>();                //a) create newNode - var of type Node<T>                   - new memory block
            newNode.mData = entry;                          // & set mData of newNode to param "entry"

            newNode.mNext = mHead;                          //b) set mNext of newNode & update mhead 
            mHead = newNode;                            
        }

        public void Append(T entry)                 // Appends entry to END of list.
        {
            Node<T> newNode = new Node<T>();                //a) create newNode - var of type Node<T>                   - new memory block
            newNode.mData = entry;                          // & set mData of newNode to param "entry"

                                                            //b) ERROR CHECK - LL empty
            if(mHead == null)
            {
                mHead = newNode;                                //Set mHead to newNode if empty
                return;
            }
                                                            //c) Iterator - find node at END - WHILE loop
            Node<T> iterator = mHead;                           //c1) create iterator - var of type Node<T>                 -> set to mHead
            while(iterator.mNext != null)                       //c2) while loop - iterate until mNext is null (end of list)
            {
                iterator = iterator.mNext;
            }
            iterator.mNext = newNode;                       //d) set mNext of iterator to newNode - new node now last node
        }


        public void Insert(T entry, int index)       // Insert entry at supplied index
        {
            Node<T> newNode = new Node<T>();                //a) create newNode - var of type Node<T> - new memory block
            newNode.mData = entry;                          //& set mData of newNode to param "entry"

                                                            //b) ERROR CHECK - index in range   -    LL empty   -    inserting @ index 0 
            int listSize = Size();                              //b1) create listSize var - get LL size. 
            if(index > listSize ||index < 0)                    //b2) check if index in range   -   index less than zero  
            {
                throw new ArgumentOutOfRangeException("index outside range in Insert function");
            }
            if(listSize==0 || index==0)                         //b3) check if LL is empty - or - if index param is 0       -> set newNode to mHead if true
            {
                newNode.mNext = mHead;                              //set mNext of newNode to mHead.        
                mHead=newNode;                                      //set mHead to newNode
                return;                                                 //Note: mHead=null if list is empty and newNode.mNext=null b/c it's 1st and last node
            }
                                                            //c) Iterator - find Node at INDEX-1 -> FOR loop
            Node<T> iterator = mHead;                           //c1) create iterator - var of type Node<T>                 -> set to mHead
            for(int i = 0; i < index-1; i++)                    //c2) for loop - iterate until index-1 (INSERT/REMOVE) 
            {                                                               
                iterator = iterator.mNext;
            }                                                       // exit loop when i (iterator) is at position prior to insert location 

                                                            //d) Set mNext of newNode & Iterator
            newNode.mNext = iterator.mNext;
            iterator.mNext = newNode;
        }

        public void RemoveHead()
        {
            if(mHead == null)                               //a) ERROR CHECK - LL is empty
            {
                throw new ArgumentNullException("Link list is empty. Can't remove from empty list");
            }
            Node<T> currentHead = mHead;                    //b) store currentHead - var type Node<T>
            mHead = mHead.mNext;                            //c) set mHead to mHead.mNext           -   move mHead to next Node
            currentHead = null;                             //d) set currentHead t0 null            -   remove reference to currentHead
        }

        
        public void Remove(int index)               // Remove entry at supplied index
        {
            if(index > Size() || index < 0)                 //a) ERROR CHECK    - index out range  - index less than 0
            {
                throw new ArgumentOutOfRangeException("index greater than LL Size or index less than 0");
            }
            if(index == 0)                                  //b) check if removing from Head  (index is 0)
            {
                RemoveHead();
                return;
            }
                                                            //c) Iterator   - find node at INDEX-1  -> FOR loop
            Node<T> iterator = mHead;                           //c1) create iterator - var type Node<T>                    -> set to mHead
            for (int i = 0; i < index - 1; i++)                 //c2) for loop - iterate until index-1 (INSERT/REMOVE) 
            {
                iterator = iterator.mNext;
            }                                                   //Exit loop when iterator = node-BEFORE-node-to-delete      
                                                                        //iterator.mNext = nodeToDelete                     

            Node<T> nodeToDelete = iterator.mNext;          //d) create/save nodeToDelete                                   -> set as iterator.mNext
            iterator.mNext = nodeToDelete.mNext;            //e) move iterator.mNext down LL line (next.next)               -> set as nodeToDelete.mNext
            nodeToDelete.mNext = null;                      //f) dereference nodeToDelet.mNext                              -> set to null

        }

        // Set entry to list entry at supplied index
        public void Replace(T entry, int index) {}

        
        public T Get(int index)                         // Returns the data contained at the provided index
        {
                                                                //a) ERROR CHECK - index in range
            if(index < 0 || index > Size())                         //check if index in range - index less than zero - or - index greater than ListSize 
            {
                throw new ArgumentOutOfRangeException("index outside range in Get Function");
            }
                                                                //b) Iterator - find node at INDEX - FOR loop      
            Node<T> iterator = mHead;                               //b1) create iterator - var of type Node<T> -> set to mHead
            for(int i = 0; i < index; i++)                          //b2) for loop - iterate until index (RETURNING VAR)
            {
                iterator = iterator.mNext;
            }
            return iterator.mData;                              //c) return mData of iterator.
        }

        
        public int Find(T entry)                        // Return index of first instance of supplied entry or -1 if not found.
        {
            bool hasFoundData = false;                          //a) create hasFound and indexCount var     -    hasFound used for case when no mData matches entry searched
            int indexCount = 0;
            int indexOfFirstMatch = 0;
                                                                //b) Iterator - find LAST - WHILE loop
            Node<T> iterator = mHead;                               //b1) create iterator - var of type Node<T> -> set to mHead
            while(iterator.mNext != null)                           //b2) while loop - iterate until mNext is null (end of LL)
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

        
        public int Size()                           // Return current size of list.
        {
            int listSize = 0;                               //a) create local "listSize" var set to 0
                                                            //b) ERROR CHECK -  if LL is empty
            if (mHead == null)                               // if LL is empty - return 0
            {
                return 0;
            }                                
                                                            //c) iterator - find LAST - WHILE LOOP
             listSize++;                                        //c1) increase "listSize" by 1      -   iterator handles iteration above size of 1. This accounts for Node at mHead.

            Node<T> iterator = mHead;                           //c1) create iterator - var of type Node<T> - set to mHead
            while (iterator.mNext != null)                      //c2) while loop - iterate until iterator.mNext is null (end of list)
            {
                iterator = iterator.mNext;                      //set iterator to iterator.mNext (next node in list to check)
                listSize++;                                        //update listSize count +1
            }                                               
            return listSize; 
        }

        // Prints all elements of the list to the screen
        public void Print() { }
    }
}
