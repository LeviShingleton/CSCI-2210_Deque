using AS_Deque;
using System.Collections;

namespace AS_Deque
{
    public class MyQueue<T> : IQueue<T>, ICollection, IEnumerable
    {
        private T[] internalArray;

        public MyQueue(int maxSize = 10)
        {
            internalArray = new T[maxSize];
            CurrentLocation = internalArray.Length - 1;
        }

        private int _count;
        public int Count
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

        private int _currentLocation;
        private int CurrentLocation
        {
            get { return _currentLocation; }
            set { _currentLocation = Math.Min(internalArray.Length - 1, value); }
        }

        public bool IsSynchronized => false;

        public object SyncRoot => this;

        public void Enqueue(T item)
        {
            Count++;
            internalArray[CurrentLocation--] = item;
        }

        public T? Dequeue()
        {
            Count--;
            CurrentLocation++;
            T result = internalArray[internalArray.Length - 1];
            for (int i = internalArray.Length - 1; i >= CurrentLocation; i--)
            {
                internalArray[i] = internalArray[i - 1];
            }
            return result;
        }

        public T? Peek()
        {
            return internalArray[internalArray.Length - 1];
        }

        public void CopyTo(Array array, int index)
        {
            if (index + Count > array.Length)
            {
                throw new ArgumentException("Target array isn't large enough to copy all elements of the stack.");
            }

            for (int i = internalArray.Length, j = 0; i > CurrentLocation; i--, j++)
            {
                array.SetValue(internalArray[i], index + j);
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = internalArray.Length - 1; i > CurrentLocation; i--)
            {
                yield return internalArray[i];
            }
        }
    }
}
