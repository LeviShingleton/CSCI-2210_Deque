///////////////////////////////////////////////////////////////////////////////
//
// Author: Aaron Shingleton, shingletona@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 3 - Deque
// Description: Basic interface for Stack functions
//
///////////////////////////////////////////////////////////////////////////////
namespace AS_Deque
{
    interface IStack<T>
    {
        public void Push(T item);
        public T? Pop();
        public T? Peek();
    }
}
