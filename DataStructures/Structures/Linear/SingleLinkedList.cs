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
               Append(arrayCopy[i]);
            }
        } 

        
        public void AddtoHead(T entry)              // Add entry to START of list.
        {
            Node<T> newNode = new Node<T>();                //a) create newNode - var of type Node<T>                   - new memory block
            newNode.mData = entry;                          // & set mData of newNode to param "entry"

            newNode.mNext = mHead;                          //b) set newNode.mNext                  -> set to mHead
            mHead = newNode;                                //c) set LL mHead                       -> set to newNode
        }

        public void Append(T entry)                 // Appends entry to END of list.
        {
            Node<T> newNode = new Node<T>();                //a) create newNode - var of type Node<T>                   - new memory block
            newNode.mData = entry;                          // & set mData of newNode to param "entry"

                                                            //b) SIZE CHECK    -   LL empty
            if(mHead == null)
            {
                mHead = newNode;                                //Set mHead to newNode if empty
                return;
            }
                                                            //c) ITERATOR FIND LAST NODE - mNext != null - WHILE LOOP
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

                                                            //b) ERROR CHECK     -   index out of range      -  index less than 0  
            if(index > Size()  || index < 0)
            {
                throw new ArgumentOutOfRangeException("index outside range in Insert function");
            }
            if(index==0)                                    //c) SIZE/INDEX CHECK   -   index 0 (add @head)    
            {
                newNode.mNext = mHead;                              //set mNext of newNode to mHead.        
                mHead=newNode;                                      //set mHead to newNode
                return;                                                 //Note: mHead=null if list is empty and newNode.mNext=null b/c it's 1st and last node
            }
                                                            //C) ITERATOR INSERT/REMOVE NODE    -   find node at Index-1     -  for loop
            Node<T> iterator = mHead;                           //c1) create iterator -                -> set to mHead
            for(int i = 0; i < index-1; i++)                    //c2) for loop - iterate until index-1 (INSERT/REMOVE) 
            {                                                               
                iterator = iterator.mNext;
            }                                                       // exit loop when i (iterator) is at position prior to insert location
                                                                    
            newNode.mNext = iterator.mNext;                 //e) Set newNode.mNext                  -> set to iterator.mNext
            iterator.mNext = newNode;                       //f) set iterator.mNext                 -> set to newNode
        }

        public void RemoveHead()
        {
            if(mHead == null)                               //a) ERROR CHECK - LL is empty
            {
                throw new ArgumentNullException("Link list is empty. Can't remove from empty list");
            }
            Node<T> currentHead = mHead;                    //b1) create currentHead                -> set to  mHead                -   store current mhead
            mHead = mHead.mNext;                            //c) update LL mHead                    -> set to mHead.mNext           -   move mHead to next Node (mHead.mNext)
            currentHead = null;                             //b3) de-ref currentHead                -> set to null                  -   removes ref to currentHead
        }

        
        public void Remove(int index)               // Remove entry at supplied index
        {
            if(index > Size() || index < 0)                 //a) ERROR CHECK    -   index out range     -    index less than 0
            {
                throw new ArgumentOutOfRangeException("index greater than LL Size or index less than 0");
            }
            if(index == 0)                                  //b) SIZE/INDEX CHECK   -   index 0 (remove @head)  
            {
                RemoveHead();
                return;
            }
                                                            //C) ITERATOR INSERT/REMOVE NODE    -   find node at Index-1     -  for loop
            Node<T> iterator = mHead;                           //c1) create iterator - var type Node<T>                    -> set to mHead
            for (int i = 0; i < index - 1; i++)                 //c2) for loop - iterate until index-1 (INSERT/REMOVE) 
            {
                iterator = iterator.mNext;
            }                                                   //Exit loop when iterator = node-BEFORE-node-to-delete      
                                                                        //iterator.mNext = nodeToDelete                     

            Node<T> nodeToDelete = iterator.mNext;          //d) create nodeToDelete                    -> set as iterator.mNext
            iterator.mNext = nodeToDelete.mNext;            //e) move iterator.mNext down LL line       -> set to nodeToDelete.mNext
            nodeToDelete.mNext = null;                      //f) de-ref nodeToDelet.mNext          -> set to null

        }

        
        public void Replace(T entry, int index)         // Set entry to list entry at supplied index
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
            Node<T> iterator = mHead;                           //c1) create iterator  - var type Node<T>                   -> set to mHead
            for(int i = 0; i < index; i++)
            {
                iterator = iterator.mNext;
            }
            iterator.mData = entry;                         //d) set mData to entry
        }

        
        public T Get(int index)                         // Returns the data contained at the provided index
        {
                                                                //a) ERROR CHECK    -   index in range      -   index less than 0
            if(index < 0 || index > Size())                        
            {
                throw new ArgumentOutOfRangeException("index outside range in Get Function");
            }
                                                                //b) ITERATOR GET/REPLACE VAR - find node at INDEX - FOR loop      
            Node<T> iterator = mHead;                               //b1) create iterator - var of type Node<T> -> set to mHead
            for(int i = 0; i < index; i++)                          //b2) for loop - iterate until index (GET VAR)
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
                                                                //b) ITERATOR FIND LAST NODE - mNext != null - WHILE LOOP
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

        
        public void Print()                         // Prints all elements of the list to the screen
        {
            if (Size() == 0)                            //a) SIZE CHECK     - LL is empty
            {
                throw new Exception("list is empty. Can't print");
            }
                                                        //b) ITERATOR FIND LAST NODE - mNext != null - WHILE LOOP
            Node<T> iterator = mHead;                       //b1) create iterator - var type Node<T>                    -> set to mHead
            while(iterator.mNext != null)
            {
                Console.WriteLine(iterator.mData);
                Console.WriteLine('\n');
                iterator = iterator.mNext;
            }
        }
    }
}
