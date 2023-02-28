///////////////////////////////////////////////////////////////////////////////
//
// Author: Aaron Shingleton, shingletona@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 3 - Deque
// Description: Program to demonstrate implementation of deque data structure
//
///////////////////////////////////////////////////////////////////////////////
namespace AS_Deque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDeque<int> deque = new MyDeque<int>();

            // A.Inserting Data
            for (int i = 0; i < 6; i++)
            {
                deque.Push(i);
            }
            for (int i = 6; i < 11; i++)
            {
                deque.Enqueue(i);
            }
            foreach (int num in deque)
                Console.WriteLine(num);

            // A.Peeking
            Console.WriteLine($"{deque.Peek(false)} is at the start, and {deque.Peek(true)} is at the end.");

            // A.Removing Data

        }
    }
}