///////////////////////////////////////////////////////////////////////////////
//
// Author: Aaron Shingleton, shingletona@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 3 - Deque
// Description: Program to demonstrate implementation of deque data structure
//
///////////////////////////////////////////////////////////////////////////////
using System.Diagnostics;

namespace AS_Deque
{
    internal class Program
    {
        #region Global Vars
        const string hr = "================================================";
        static MyDeque<int> Deque = new MyDeque<int>();
        #endregion
        static void Main(string[] args)
        {
            

            // A.Inserting Data
            for (int i = 0; i < 10; i++)
            {
                Deque.Push(i);
            }
            for (int i = 10; i < 20; i++)
            {
                Deque.Enqueue(i);
            }

            PrintDeque();

            // A.Peeking
            Console.WriteLine($"{Deque.Peek(false)} is at the start of the deque, and {Deque.Peek(true)} is at the end of the deque.\n\n");

            // A.Removing Data
            Console.WriteLine($"Removing data - first 3 of each\n{hr}");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Front: {Deque.Pop()}    Back : {Deque.Dequeue()}");
            }

            PrintDeque();

            Console.WriteLine($"The deque is actually larger than size {Deque.Count}, but filler zeroes from resizing (def. 10) are ignored.");
        }
        static void PrintDeque()
        {
            Console.WriteLine(hr);

            Console.WriteLine("Data in deque");
            foreach (int num in Deque)
                Console.WriteLine(num);

            Console.WriteLine(hr);
        }
    }
}