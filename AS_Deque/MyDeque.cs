///////////////////////////////////////////////////////////////////////////////
//
// Author: Aaron Shingleton, shingletona@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 3 - Deque
// Description: Hilariously lobotomized deque data structure that is
//              a funny amalgam of a stack and a queue.
//
///////////////////////////////////////////////////////////////////////////////
using System.Collections;

namespace AS_Deque
{
    public class MyDeque<T> : IStack<T>, IQueue<T>, ICollection
    {
        private int _count = 0;
        private T[] internalArray;
        private bool PeekFlag = false;
        public int Count            // Although not used to insert data, tally of useful elements is used to help with upsizing array.
        {
            get
            {
                return _count;
            }
            private set
            {
                _count = Math.Max(0, value);
            }
        }

        public MyDeque(int maxSize = 10)
        {
            internalArray = new T[maxSize];
            BackLocation = internalArray.Length - 1;
        }

        public bool IsSynchronized => false;

        public object SyncRoot => this;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void CopyTo(Array array, int index)
        {
            try
            {
                // Transfer front
                for (int i = 0; i < Count; i++)
                {
                    array.SetValue(internalArray[i], index + i);
                }
                // Transfer back
                for (int i = internalArray.Length, j = 0; i > BackLocation; i--, j++)
                {
                    array.SetValue(internalArray[i], index + j);
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Arugment array can not fit contents of deque.");
                Console.WriteLine(e);
            }
        }


        #region Queue Components
        private int _backLoc;
        private int BackLocation
        {
            get { return _backLoc; }
            set { _backLoc = Math.Min(internalArray.Length - 1, value); }
        }
        /// <summary>
        /// Removes the item at the end of the deque and returns it.
        /// </summary>
        /// <returns>The item at the end of the deque.</returns>
        public T? Dequeue()
        {
            PeekFlag = true;
            Count--;
            BackLocation++;
            T result = internalArray[internalArray.Length - 1];
            for (int i = internalArray.Length - 1; i >= BackLocation; i--)
            {
                internalArray[i] = internalArray[i - 1];
            }
            return result;
        }
        /// <summary>
        /// Adds an item to the back of the deque. 
        /// FIXME: Does not work with a loop that would cause overlap between the front and back ends of the deque.
        /// </summary>
        /// <param name="item">The item to be inserted at the back of the deque.</param>
        public void Enqueue(T item)
        {
            PeekFlag = true;
            Count++;
            internalArray[BackLocation--] = item;

            // Resize if overlap would occur b/w front and back on next call
            if (FrontLocation > BackLocation)
            {
                Resize();
            }
        }
        #endregion

        #region Stack Components
        private int _frontLoc = 0;
        private int FrontLocation
        {
            get { return _frontLoc; }
            set { _frontLoc = Math.Max(0, value); }
        }

        public T? Pop()
        {
            PeekFlag = false;
            Count--;
            if (FrontLocation == 0) { return default(T); }
            return internalArray[--FrontLocation];
        }

        public void Push(T item)
        {
            PeekFlag = false;
            Count++;
            internalArray[FrontLocation++] = item;
            // Resize if next call would overlap
            if (FrontLocation > BackLocation)
            {
                Resize();

            }
        }
        #endregion

        /// <summary>
        /// Returns the item at the start or end of the deque, depending on previous actions with deque. Defaults to front.
        /// </summary>
        /// <returns>Item at front or back of deque.</returns>
        public T? Peek()
        {
            // Queue behavior
            if (PeekFlag)
            {
                return internalArray[internalArray.Length - 1];
            }
            // Stack Behavior
            else
            {
                return internalArray[0];
            }
        }
        /// <summary>
        /// Wrapper overload for interface Peek(), sets PeekFlag to determine behavior of Peek()
        /// </summary>
        /// <param name="peekBack">Whether or not to peek from the back. If false, peeks from beginning of array.</param>
        /// <returns>Item at beginning or end of array, depending on peekBack.</returns>
        public T? Peek(bool peekBack)
        {
            PeekFlag = peekBack;
            return Peek();
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0, j = internalArray.Length - 1; i <= Count; i++)
            {
                if (i < FrontLocation) yield return internalArray[i];
                else if (i > FrontLocation) yield return internalArray[j--];
            }
        }
        /// <summary>
        /// Expands deque to fit larger size. Automatically called when pushing/enqueueing and overlap would occur with previously inserted elements.
        /// </summary>
        public bool Resize()
        {
            T[] temp = new T[internalArray.Length * 2];

            for (int i = 0; i < FrontLocation; i++)
            {
                temp[i] = internalArray[i];
            }

            int tempQueuePlacer = temp.Length - 1;
            for (int i = internalArray.Length - 1; i >= BackLocation; i--)
            {
                temp[tempQueuePlacer--] = internalArray[i];
            }

            internalArray = temp;
            BackLocation = internalArray.Length - BackLocation;
            return true;
        }
        
    }
}
