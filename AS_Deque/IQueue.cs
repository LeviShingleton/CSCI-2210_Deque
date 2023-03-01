///////////////////////////////////////////////////////////////////////////////
//
// Author: Aaron Shingleton, shingletona@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 3 - Deque
// Description: Basic interface for Queue functions
//
///////////////////////////////////////////////////////////////////////////////
namespace AS_Deque
{
    internal interface IQueue<T>
    {
        public void Enqueue(T item);
        public T? Dequeue();
        public T? Peek();
    }
}
