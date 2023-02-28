using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS_Deque
{
    internal interface IQueue<T>
    {
        public void Enqueue(T item);
        public T? Dequeue();
        public T? Peek();
    }
}
