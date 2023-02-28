using AS_Deque;
using System.Collections;

namespace AS_Deque
{
    public class MyStack<T> : ICollection, IEnumerable, IStack<T> where T : IComparable
    {
        private T[] internalArray;

        public MyStack(int maxSize = 10)
        {
            internalArray = new T[maxSize];
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

        public bool IsSynchronized => false;

        public object SyncRoot => this;

        public void CopyTo(Array array, int index)
        {
            if (index + Count > array.Length)
            {
                throw new ArgumentException("Target array isn't large enough to copy all elements of the stack.");
            }

            for (int i = 0; i < Count; i++)
            {
                array.SetValue(internalArray[i], index + i);
            }
        }

        public IEnumerator GetEnumerator()
        {
            //return internalArray.GetEnumerator();
            for (int i = 0; i < Count; i++)
            {
                yield return internalArray[i];
            }
        }

        public void Push(T value)
        {
            internalArray[Count++] = value;
        }

        public T? Pop()
        {
            if (Count == 0) { return default(T); }
            return internalArray[--Count];
        }

        public T? Peek() => Count == 0 ? default(T) : internalArray[Count - 1];
    }
}
