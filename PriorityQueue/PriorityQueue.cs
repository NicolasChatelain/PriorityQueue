using System.Collections;

namespace PriorityQueue
{
    public class PriorityQueue<T> : IPQ<T>, IEnumerable<T>
    {
        private readonly List<(T item, int prio)> _queue = [];

        public int Count { get { return _queue.Count; } }

        public bool IsEmpty { get { return _queue.Count == 0; } }

        public void Enqueue(T item, int prio)
        {
            var newElement = (item, prio);
            int index = _queue.FindIndex(x => x.prio > prio);

            if (index >= 0)
            {
                _queue.Insert(index, newElement);
            }
            else
            {
                _queue.Add(newElement);
            }

        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Dequeue attempt on empty queue.");
            }

            var (item, _) = _queue[0];
            _queue.RemoveAt(0);
            return item;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Peek was called but the priority queue is empty.");
            }

            var (item, _) = _queue[0];
            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _queue[i].item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}
