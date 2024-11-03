using System;
using VFS.GD.TestFramework;

namespace DataStructures
{
    /// <summary>
    /// Class responsible to run a group of tests.
    /// </summary>
    class TestRepository
    {
        /// <summary>
        /// Creates a group of tests and display their results on the screen.
        /// Each test should be a static method that constructs and returns a Test.
        /// </summary>
        public static void RunTests()
        {
            // The naming convention for test methods is Setup_Action_Expected.
            // Where Setup represents the initial state, Action is usually the method we want to evaluate, 
            // and Expected is the expected result.
            Test[] sllTests = {
                NewSLL_Size_IsEmpty(),
                NewSLL_Append_SizeChanges(),
                SLLWithElements_Get_SLLContainsElements(),
                SLLWithElements_GetAtInvalidIndex_ExceptionCaught(),
                SLLWithElements_Insert_SLLContainsElement(),
                SLLWithElements_InsertAtInvalidIndex_ExceptionCaught(),
                SLLWithElements_Remove_SLLSizeChanges(),
                SLLWithElements_RemoveAtInvalidIndex_ExceptionCaught(),
                SLLWithElements_Replace_SLLContainsElement(),
                SLLWithElements_ReplaceAtInvalidIndex_ExceptionCaught(),
                SLLWithElements_Find_IndexFound(),
                SLLWithElements_FindUnexistingElement_IndexNotFound(),
            };
            TestGroup sllTestGroup = new TestGroup("SingularLinkedList");
            sllTestGroup.Tests = sllTests;

            Test[] dllTests = {
                NewDLL_Size_IsEmpty(),
                NewDLL_Append_SizeChanges(),
                DLLWithElements_Get_DLLContainsElements(),
                DLLWithElements_GetAtInvalidIndex_ExceptionCaught(),
                DLLWithElements_Insert_DLLContainsElement(),
                DLLWithElements_InsertAtInvalidIndex_ExceptionCaught(),
                DLLWithElements_Remove_DLLSizeChanges(),
                DLLWithElements_RemoveAtInvalidIndex_ExceptionCaught(),
                DLLWithElements_Replace_DLLContainsElement(),
                DLLWithElements_ReplaceAtInvalidIndex_ExceptionCaught(),
                DLLWithElements_Find_IndexFound(),
                DLLWithElements_FindUnexistingElement_IndexNotFound(),
            };
            TestGroup dllTestGroup = new TestGroup("DoubleLinkedList");
            dllTestGroup.Tests = dllTests;

            Test[] cllTests = {
                NewCLL_Size_IsEmpty(),
                NewCLL_Append_SizeChanges(),
                CLLWithElements_Get_CLLContainsElements(),
                CLLWithElements_GetAtInvalidIndex_ExceptionCaught(),
                CLLWithElements_Insert_CLLContainsElement(),
                CLLWithElements_InsertAtInvalidIndex_ExceptionCaught(),
                CLLWithElements_Remove_CLLSizeChanges(),
                CLLWithElements_RemoveAtInvalidIndex_ExceptionCaught(),
                CLLWithElements_Replace_CLLContainsElement(),
                CLLWithElements_ReplaceAtInvalidIndex_ExceptionCaught(),
                CLLWithElements_Find_IndexFound(),
                CLLWithElements_FindUnexistingElement_IndexNotFound(),
            };
            TestGroup cllTestGroup = new TestGroup("CircularLinkedList");
            cllTestGroup.Tests = cllTests;

            Test[] stackTests = {
                NewStack_Size_Zero(),
                NewStack_Push_SizeChanges(),
                StackWithElements_Pop_TopElementRemoved(),
                NewStack_Pop_ExceptionCaught(),
                StackWithElements_Peek_TopElementFoundNotRemoved(),
                NewStack_Peek_ExceptionCaught(),
                NewStack_IsEmpty_True(),
                StackWithElements_IsEmpty_False(),
            };
            TestGroup stackTestGroup = new TestGroup("Stack");
            stackTestGroup.Tests = stackTests;

            Test[] queueTests = {
                NewQueue_Size_Zero(),
                NewQueue_Enqueue_SizeChanges(),
                QueueWithElements_Dequeue_FrontElementRemoved(),
                NewQueue_Dequeue_ExceptionCaught(),
                NewQueue_IsEmpty_True(),
                QueueWithElements_IsEmpty_False(),
            };
            TestGroup queueTestGroup = new TestGroup("Queue");
            queueTestGroup.Tests = queueTests;

            TestGroup[] testGroups = { sllTestGroup, dllTestGroup, cllTestGroup, stackTestGroup, queueTestGroup };

            TestOutput.PrintTestResults(testGroups);
        }

        private static Test NewSLL_Size_IsEmpty()
        {
            Test t = new Test("NewSLL_Size_IsEmpty");
            SingleLinkedList<int> sll = new SingleLinkedList<int>();

            int sllSize = sll.Size();

            t.Assert(sllSize == 0);
            return t;
        }

        private static Test NewSLL_Append_SizeChanges()
        {
            Test t = new Test("NewSLL_Append_SizeChanges");
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            int originalSize = sll.Size();
            
            sll.Append(0);
            sll.Append(1);
            sll.Append(2);
            sll.Append(3);
            sll.Append(4);
            sll.Append(5);
            sll.Append(6);
            sll.Append(7);
            sll.Append(8);
            sll.Append(9);

            t.Assert(originalSize == 0);
            t.Assert(sll.Size() == 10);
            return t;
        }

        private static Test SLLWithElements_Get_SLLContainsElements()
        {
            Test t = new Test("SLLWithElements_Get_SLLContainsElements");
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                sll.Append(i);
            }

            for (int i = 0; i < 10; i++)
            {
                t.Assert(sll.Get(i) == i);
            }
            return t;
        }

        private static Test SLLWithElements_GetAtInvalidIndex_ExceptionCaught()
        {
            Test t = new Test("SLLWithElements_GetAtInvalidIndex_ExceptionCaught");
            int outOfRangeIndex = 100;
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                sll.Append(i);
            }

            try
            {
                sll.Get(outOfRangeIndex);
                t.Assert(false);
            }
            catch (ArgumentOutOfRangeException)
            {
                t.Assert(true);
            }
            return t;
        }

        private static Test SLLWithElements_Insert_SLLContainsElement()
        {
            Test t = new Test("SLLWithElements_Insert_SLLContainsElement");
            int expectedElement = 100;
            int expectedIndex = 5;
            int expectedSize = 11;
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                sll.Append(i);
            }

            sll.Insert(expectedElement, expectedIndex);

            t.Assert(sll.Get(expectedIndex) == expectedElement);
            t.Assert(sll.Size() == expectedSize);
            return t;
        }

        private static Test SLLWithElements_InsertAtInvalidIndex_ExceptionCaught()
        {
            Test t = new Test("SLLWithElements_InsertAtInvalidIndex_ExceptionCaught");
            int expectedElement = 100;
            int invalidIndex = 100;
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                sll.Append(i);
            }

            try
            {
                sll.Insert(expectedElement, invalidIndex);
                t.Assert(false);
            }
            catch (ArgumentOutOfRangeException)
            {
                t.Assert(true);
            }

            return t;
        }

        private static Test SLLWithElements_Remove_SLLSizeChanges()
        {
            Test t = new Test("SLLWithElements_Remove_SLLSizeChanges");
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                sll.Append(i);
            }

            sll.Remove(0);
            sll.Remove(7);

            t.Assert(sll.Get(0) == 1);
            t.Assert(sll.Get(7) == 9);
            t.Assert(sll.Size() == 8);
            return t;
        }

        private static Test SLLWithElements_RemoveAtInvalidIndex_ExceptionCaught()
        {
            Test t = new Test("SLLWithElements_RemoveAtInvalidIndex_ExceptionCaught");
            int invalidIndex = 100;
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                sll.Append(i);
            }

            try
            {
                sll.Remove(invalidIndex);
                t.Assert(false);
            }
            catch (ArgumentOutOfRangeException)
            {
                t.Assert(true);
            }

            return t;
        }

        private static Test SLLWithElements_Replace_SLLContainsElement()
        {
            Test t = new Test("SLLWithElements_Replace_SLLContainsElement");
            int expectedElement = 100;
            int expectedIndex = 5;
            int expectedSize = 10;
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                sll.Append(i);
            }

            sll.Replace(expectedElement, expectedIndex);

            t.Assert(sll.Get(expectedIndex) == expectedElement);
            t.Assert(sll.Size() == expectedSize);
            return t;
        }

        private static Test SLLWithElements_ReplaceAtInvalidIndex_ExceptionCaught()
        {
            Test t = new Test("SLLWithElements_ReplaceAtInvalidIndex_ExceptionCaught");
            int invalidIndex = 100;
            int expectedElement = 100;
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                sll.Append(i);
            }

            try
            {
                sll.Replace(invalidIndex, expectedElement);
                t.Assert(false);
            }
            catch (ArgumentOutOfRangeException)
            {
                t.Assert(true);
            }

            return t;
        }

        private static Test SLLWithElements_Find_IndexFound()
        {
            Test t = new Test("SLLWithElements_Find_IndexFound");
            int expectedElement = 10;
            int expectedIndex = 5;
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                sll.Append(i*2);
            }

            int findResult = sll.Find(expectedElement);

            t.Assert(findResult == expectedIndex);
            return t;
        }

        private static Test SLLWithElements_FindUnexistingElement_IndexNotFound()
        {
            Test t = new Test("SLLWithElements_FindUnexistingElement_IndexNotFound");
            int unexistingElement = 100;
            SingleLinkedList<int> sll = new SingleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                sll.Append(i);
            }

            int findResult = sll.Find(unexistingElement);

            t.Assert(findResult == -1);
            return t;
        }

        private static Test NewDLL_Size_IsEmpty()
        {
            Test t = new Test("NewDLL_Size_IsEmpty");
            DoubleLinkedList<int> dll = new DoubleLinkedList<int>();

            int dllSize = dll.Size();

            t.Assert(dllSize == 0);
            return t;
        }

        private static Test NewDLL_Append_SizeChanges()
        {
            Test t = new Test("NewDLL_Append_SizeChanges");
            DoubleLinkedList<int> dll = new DoubleLinkedList<int>();
            int originalSize = dll.Size();

            dll.Append(0);
            dll.Append(1);
            dll.Append(2);
            dll.Append(3);
            dll.Append(4);
            dll.Append(5);
            dll.Append(6);
            dll.Append(7);
            dll.Append(8);
            dll.Append(9);

            t.Assert(originalSize == 0);
            t.Assert(dll.Size() == 10);
            return t;
        }

        private static Test DLLWithElements_Get_DLLContainsElements()
        {
            Test t = new Test("DLLWithElements_Get_DLLContainsElements");
            DoubleLinkedList<int> dll = new DoubleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                dll.Append(i);
            }

            for (int i = 0; i < 10; i++)
            {
                t.Assert(dll.Get(i) == i);
            }
            return t;
        }

        private static Test DLLWithElements_GetAtInvalidIndex_ExceptionCaught()
        {
            Test t = new Test("DLLWithElements_GetAtInvalidIndex_ExceptionCaught");
            int outOfRangeIndex = 100;
            DoubleLinkedList<int> dll = new DoubleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                dll.Append(i);
            }

            try
            {
                dll.Get(outOfRangeIndex);
                t.Assert(false);
            }
            catch (ArgumentOutOfRangeException)
            {
                t.Assert(true);
            }
            return t;
        }

        private static Test DLLWithElements_Insert_DLLContainsElement()
        {
            Test t = new Test("DLLWithElements_Insert_DLLContainsElement");
            int expectedElement = 100;
            int expectedIndex = 5;
            int expectedSize = 11;
            DoubleLinkedList<int> dll = new DoubleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                dll.Append(i);
            }

            dll.Insert(expectedElement, expectedIndex);

            t.Assert(dll.Get(expectedIndex) == expectedElement);
            t.Assert(dll.Size() == expectedSize);
            return t;
        }

        private static Test DLLWithElements_InsertAtInvalidIndex_ExceptionCaught()
        {
            Test t = new Test("DLLWithElements_InsertAtInvalidIndex_ExceptionCaught");
            int expectedElement = 100;
            int invalidIndex = 100;
            DoubleLinkedList<int> dll = new DoubleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                dll.Append(i);
            }

            try
            {
                dll.Insert(expectedElement, invalidIndex);
                t.Assert(false);
            }
            catch (ArgumentOutOfRangeException)
            {
                t.Assert(true);
            }

            return t;
        }

        private static Test DLLWithElements_Remove_DLLSizeChanges()
        {
            Test t = new Test("DLLWithElements_Remove_DLLSizeChanges");
            DoubleLinkedList<int> dll = new DoubleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                dll.Append(i);
            }

            dll.Remove(0);
            dll.Remove(7);

            t.Assert(dll.Get(0) == 1);
            t.Assert(dll.Get(7) == 9);
            t.Assert(dll.Size() == 8);
            return t;
        }

        private static Test DLLWithElements_RemoveAtInvalidIndex_ExceptionCaught()
        {
            Test t = new Test("DLLWithElements_RemoveAtInvalidIndex_ExceptionCaught");
            int invalidIndex = 100;
            DoubleLinkedList<int> dll = new DoubleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                dll.Append(i);
            }

            try
            {
                dll.Remove(invalidIndex);
                t.Assert(false);
            }
            catch (ArgumentOutOfRangeException)
            {
                t.Assert(true);
            }

            return t;
        }

        private static Test DLLWithElements_Replace_DLLContainsElement()
        {
            Test t = new Test("DLLWithElements_Replace_DLLContainsElement");
            int expectedElement = 100;
            int expectedIndex = 5;
            int expectedSize = 10;
            DoubleLinkedList<int> dll = new DoubleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                dll.Append(i);
            }

            dll.Replace(expectedElement, expectedIndex);

            t.Assert(dll.Get(expectedIndex) == expectedElement);
            t.Assert(dll.Size() == expectedSize);
            return t;
        }

        private static Test DLLWithElements_ReplaceAtInvalidIndex_ExceptionCaught()
        {
            Test t = new Test("DLLWithElements_ReplaceAtInvalidIndex_ExceptionCaught");
            int invalidIndex = 100;
            int expectedElement = 100;
            DoubleLinkedList<int> dll = new DoubleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                dll.Append(i);
            }

            try
            {
                dll.Replace(invalidIndex, expectedElement);
                t.Assert(false);
            }
            catch (ArgumentOutOfRangeException)
            {
                t.Assert(true);
            }

            return t;
        }

        private static Test DLLWithElements_Find_IndexFound()
        {
            Test t = new Test("DLLWithElements_Find_IndexFound");
            int expectedElement = 10;
            int expectedIndex = 5;
            DoubleLinkedList<int> dll = new DoubleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                dll.Append(i * 2);
            }

            int findResult = dll.Find(expectedElement);

            t.Assert(findResult == expectedIndex);
            return t;
        }

        private static Test DLLWithElements_FindUnexistingElement_IndexNotFound()
        {
            Test t = new Test("DLLWithElements_FindUnexistingElement_IndexNotFound");
            int unexistingElement = 100;
            DoubleLinkedList<int> dll = new DoubleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                dll.Append(i);
            }

            int findResult = dll.Find(unexistingElement);
            
            t.Assert(findResult == -1);
            return t;
        }

        private static Test NewCLL_Size_IsEmpty()
        {
            Test t = new Test("NewCLL_Size_IsEmpty");
            CircularLinkedList<int> cll = new CircularLinkedList<int>();

            int cllSize = cll.Size();

            t.Assert(cllSize == 0);
            return t;
        }

        private static Test NewCLL_Append_SizeChanges()
        {
            Test t = new Test("NewCLL_Append_SizeChanges");
            CircularLinkedList<int> cll = new CircularLinkedList<int>();
            int originalSize = cll.Size();

            cll.Append(0);
            cll.Append(1);
            cll.Append(2);
            cll.Append(3);
            cll.Append(4);
            cll.Append(5);
            cll.Append(6);
            cll.Append(7);
            cll.Append(8);
            cll.Append(9);

            t.Assert(originalSize == 0);
            t.Assert(cll.Size() == 10);
            return t;
        }

        private static Test CLLWithElements_Get_CLLContainsElements()
        {
            Test t = new Test("CLLWithElements_Get_CLLContainsElements");
            CircularLinkedList<int> cll = new CircularLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                cll.Append(i);
            }

            for (int i = 0; i < 10; i++)
            {
                t.Assert(cll.Get(i) == i);
            }
            return t;
        }

        private static Test CLLWithElements_GetAtInvalidIndex_ExceptionCaught()
        {
            Test t = new Test("CLLWithElements_GetAtInvalidIndex_ExceptionCaught");
            int outOfRangeIndex = 100;
            CircularLinkedList<int> cll = new CircularLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                cll.Append(i);
            }

            try
            {
                cll.Get(outOfRangeIndex);
                t.Assert(false);
            }
            catch (ArgumentOutOfRangeException)
            {
                t.Assert(true);
            }

            return t;
        }

        private static Test CLLWithElements_Insert_CLLContainsElement()
        {
            Test t = new Test("CLLWithElements_Insert_CLLContainsElement");
            int expectedElement = 100;
            int expectedIndex = 5;
            int expectedSize = 11;
            CircularLinkedList<int> cll = new CircularLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                cll.Append(i);
            }

            cll.Insert(expectedElement, expectedIndex);

            t.Assert(cll.Get(expectedIndex) == expectedElement);
            t.Assert(cll.Size() == expectedSize);
            return t;
        }

        private static Test CLLWithElements_InsertAtInvalidIndex_ExceptionCaught()
        {
            Test t = new Test("CLLWithElements_InsertAtInvalidIndex_ExceptionCaught");
            int expectedElement = 100;
            int outOfRangeIndex = 100;
            CircularLinkedList<int> cll = new CircularLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                cll.Append(i);
            }

            try
            {
                cll.Insert(expectedElement, outOfRangeIndex);
                t.Assert(false);
            }
            catch (ArgumentOutOfRangeException)
            {

                t.Assert(true);
            }

            return t;
        }

        private static Test CLLWithElements_Remove_CLLSizeChanges()
        {
            Test t = new Test("CLLWithElements_Remove_CLLSizeChanges");
            CircularLinkedList<int> cll = new CircularLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                cll.Append(i);
            }

            cll.Remove(0);
            cll.Remove(7);

            t.Assert(cll.Get(0) == 1);
            t.Assert(cll.Get(7) == 9);
            t.Assert(cll.Size() == 8);
            return t;
        }

        private static Test CLLWithElements_RemoveAtInvalidIndex_ExceptionCaught()
        {
            Test t = new Test("CLLWithElements_RemoveAtInvalidIndex_ExceptionCaught");
            int outOfRangeIndex = 100;
            CircularLinkedList<int> cll = new CircularLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                cll.Append(i);
            }

            try
            {
                cll.Remove(outOfRangeIndex);
                t.Assert(false);
            }
            catch (ArgumentOutOfRangeException)
            {

                t.Assert(true);
            }
            return t;
        }

        private static Test CLLWithElements_Replace_CLLContainsElement()
        {
            Test t = new Test("CLLWithElements_Replace_CLLContainsElement");
            int expectedElement = 100;
            int expectedIndex = 5;
            int expectedSize = 10;
            CircularLinkedList<int> cll = new CircularLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                cll.Append(i);
            }

            cll.Replace(expectedElement, expectedIndex);

            t.Assert(cll.Get(expectedIndex) == expectedElement);
            t.Assert(cll.Size() == expectedSize);
            return t;
        }

        private static Test CLLWithElements_ReplaceAtInvalidIndex_ExceptionCaught()
        {
            Test t = new Test("CLLWithElements_ReplaceAtInvalidIndex_ExceptionCaught");
            int outOfRangeIndex = 100;
            int expectedElement = 100;
            CircularLinkedList<int> cll = new CircularLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                cll.Append(i);
            }

            try
            {
                cll.Replace(outOfRangeIndex, expectedElement);
                t.Assert(false);
            }
            catch (ArgumentOutOfRangeException)
            {

                t.Assert(true);
            }
            return t;
        }

        private static Test CLLWithElements_Find_IndexFound()
        {
            Test t = new Test("CLLWithElements_Find_IndexFound");
            int expectedElement = 10;
            int expectedIndex = 5;
            CircularLinkedList<int> cll = new CircularLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                cll.Append(i * 2);
            }

            int findResult = cll.Find(expectedElement);

            t.Assert(findResult == expectedIndex);
            return t;
        }

        private static Test CLLWithElements_FindUnexistingElement_IndexNotFound()
        {
            Test t = new Test("CLLWithElements_FindUnexistingElement_IndexNotFound");
            int unexistingElement = 100;
            CircularLinkedList<int> cll = new CircularLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                cll.Append(i*2);
            }

            int findResult = cll.Find(unexistingElement);

            t.Assert(findResult == -1); 
            return t;
        }

        private static Test NewStack_Size_Zero()
        {
            Test t = new Test("NewStack_Size_Zero");
            Stack<int> stack = new Stack<int>();

            t.Assert(stack.Size() == 0);

            return t;
        }

        private static Test NewStack_Push_SizeChanges()
        {
            Test t = new Test("NewStack_Push_SizeChanges");
            int expectedSize = 10;
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            t.Assert(stack.Size() == expectedSize);

            return t;
        }

        private static Test StackWithElements_Pop_TopElementRemoved()
        {
            Test t = new Test("StackWithElements_Pop_TopElementRemoved");
            int expectedSize = 9;
            int expectedElement = 9;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            int foundElement = stack.Pop();

            t.Assert(foundElement == expectedElement);
            t.Assert(stack.Size() == expectedSize);
            return t;
        }

        private static Test NewStack_Pop_ExceptionCaught()
        {
            Test t = new Test("NewStack_Pop_ExceptionCaught");
            Stack<int> stack = new Stack<int>();

            try
            {
                stack.Pop();
                t.Assert(false);
            }
            catch (InvalidOperationException)
            {

                t.Assert(true);
            }

            return t;
        }

        private static Test StackWithElements_Peek_TopElementFoundNotRemoved()
        {
            Test t = new Test("StackWithElements_Peek_TopElementFoundNotRemoved");
            int expectedSize = 10;
            int expectedElement = 9;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            int foundElement = stack.Peek();

            t.Assert(foundElement == expectedElement);
            t.Assert(stack.Size() == expectedSize);
            return t;
        }

        private static Test NewStack_Peek_ExceptionCaught()
        {
            Test t = new Test("NewStack_Peek_ExceptionCaught");
            Stack<int> stack = new Stack<int>();

            try
            {
                stack.Peek();
                t.Assert(false);
            }
            catch (InvalidOperationException)
            {

                t.Assert(true);
            }

            return t;
        }

        private static Test NewStack_IsEmpty_True()
        {
            Test t = new Test("NewStack_IsEmpty_True");
            Stack<int> stack = new Stack<int>();

            t.Assert(stack.IsEmpty());
            return t;
        }

        private static Test StackWithElements_IsEmpty_False()
        {
            Test t = new Test("StackWithElements_IsEmpty_False");
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            t.Assert(!stack.IsEmpty());
            return t;
        }

        private static Test NewQueue_Size_Zero()
        {
            Test t = new Test("NewQueue_Size_Zero");
            Queue<int> queue = new Queue<int>();

            t.Assert(queue.Size() == 0);

            return t;
        }

        private static Test NewQueue_Enqueue_SizeChanges()
        {
            Test t = new Test("NewQueue_Enqueue_SizeChanges");
            int expectedSize = 10;
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            t.Assert(queue.Size() == expectedSize);
            return t;
        }

        private static Test QueueWithElements_Dequeue_FrontElementRemoved()
        {
            Test t = new Test("QueueWithElements_Dequeue_FrontElementRemoved");
            int expectedSize = 9;
            int expectedElement = 0;
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            int frontElement = queue.Dequeue();

            t.Assert(frontElement == expectedElement);
            t.Assert(queue.Size() == expectedSize);
            return t;
        }

        private static Test NewQueue_Dequeue_ExceptionCaught()
        {
            Test t = new Test("NewQueue_Dequeue_ExceptionCaught");
            Queue<int> queue = new Queue<int>();

            try
            {
                queue.Dequeue();
                t.Assert(false);
            }
            catch (InvalidOperationException)
            {
                t.Assert(true);
            }
            
            return t;
        }

        private static Test NewQueue_IsEmpty_True()
        {
            Test t = new Test("NewQueue_IsEmpty_True");
            Queue<int> queue = new Queue<int>();

            t.Assert(queue.IsEmpty());

            return t;
        }

        private static Test QueueWithElements_IsEmpty_False()
        {
            Test t = new Test("QueueWithElements_IsEmpty_False");
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            t.Assert(!queue.IsEmpty());

            return t;
        }
    }
}
