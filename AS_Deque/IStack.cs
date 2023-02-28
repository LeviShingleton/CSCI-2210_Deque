namespace AS_Deque
{
    interface IStack<T>
    {
        public void Push(T item);
        public T? Pop();
        public T? Peek();
    }
}
