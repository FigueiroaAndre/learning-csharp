using System;

namespace EventsAndGenerics
{
    public class Logger<T>
    {
        public void OnEnqueued(object source, T value )
        {
            System.Console.WriteLine($"Log: {value} Enqueued!");
        }

        public void OnDequeued(object source, T value)
        {
            System.Console.WriteLine($"Log: {value} Dequeued!");
        }
    }
}