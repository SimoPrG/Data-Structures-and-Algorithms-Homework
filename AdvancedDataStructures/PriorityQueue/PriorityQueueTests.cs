namespace PriorityQueue
{
    using System;
    public class PriorityQueueTests
    {
        public static void Main()
        {
            var queue = new PriorityQueue<int>(true);

            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(3);
            queue.Enqueue(1);
            queue.Enqueue(1);

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Peek());
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
