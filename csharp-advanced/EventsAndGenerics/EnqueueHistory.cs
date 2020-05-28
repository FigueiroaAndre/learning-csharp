using System;
using System.Collections.Generic;

namespace EventsAndGenerics
{
    public class EnqueueHistory<T>
    {
        private List<Tuple<DateTime,T>> _history;

        public EnqueueHistory()
        {
            _history = new List<Tuple<DateTime,T>>();
        }

        public void Print()
        {
            foreach (var pair in _history)
            {
                System.Console.WriteLine($"{pair.Item2} Enqueued at {pair.Item1}!");
            }
        }

        public void OnEnqueued(object source, T value)
        {
            var tuple = new Tuple<DateTime,T>(DateTime.Now,value);
            _history.Add(tuple);
        }
    }
}