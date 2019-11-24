using System.Collections.Concurrent;

namespace Data_Collector
{
    internal class FixedSizeQueue<T>    // code for fixed size queue that auto-dequeues when limit reached
    {
        public ConcurrentQueue<T> q = new ConcurrentQueue<T>();
        private object lockObject = new object();
        public int Limit { get; set; }

        // enqueue method to automatically dequeue when limit reached
        public void Enqueue(T obj)
        {
            q.Enqueue(obj);
            lock (lockObject)
            {
                T overflow;
                while (q.Count > Limit && q.TryDequeue(out overflow)) ;
            }
        }
        
    }
}