using System;
using System.Collections.Generic;

namespace EventsAndGenerics
{
    public class PublisherQueue<T>
    {
        public event EventHandler<T> EnqueuedEventHandler;
        public event EventHandler<T> DequeuedEventHandler;
        private Queue<T> _queue;

        public PublisherQueue()
        {
            _queue = new Queue<T>();
        }

        public void Enqueue(T value)
        {
            _queue.Enqueue(value);
            OnEnqueued(value);
        }

        public T Dequeue()
        {
            if (_queue.Count == 0)
            {
                throw new InvalidOperationException("Queue was already empty.");
            }
            T dequeuedValue = _queue.Dequeue();
            OnDequeued(dequeuedValue);
            return dequeuedValue;
        }

        protected virtual void OnEnqueued(T e)
        {
            if (EnqueuedEventHandler != null)
                EnqueuedEventHandler(this,e);
        }

        protected virtual void OnDequeued(T e)
        {
            if (DequeuedEventHandler != null)
                DequeuedEventHandler(this,e);
        }

    }
}