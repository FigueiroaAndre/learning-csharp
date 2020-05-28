using System;
using System.Threading;

namespace EventsAndGenerics
{
    class Program
    {

        static void Main(string[] args)
        {
            var queue = new PublisherQueue<int>();
            var logger = new Logger<int>();
            var history = new EnqueueHistory<int>();
            var random = new Random();
            queue.EnqueuedEventHandler += logger.OnEnqueued;
            queue.DequeuedEventHandler += logger.OnDequeued;
            queue.EnqueuedEventHandler += history.OnEnqueued;
            for(int i = 0; i < 10; i++)
            {
                int randomSleepTime = random.Next(5000);
                int randomValue = random.Next();
                queue.Enqueue(randomValue);
                Thread.Sleep(randomSleepTime); //0 to 5s
            }
            int numOfDequeue = random.Next(10);
            for(int i = 0; i < numOfDequeue; i++)
            {
                queue.Dequeue();
            }
            history.Print();
        }
    }
}
