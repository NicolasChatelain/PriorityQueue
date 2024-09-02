namespace PriorityQueue
{
    internal interface IPQ<T>
    {
        public void Enqueue(T item, int prio);
        public T Dequeue();
        public T Peek();
    }
}
