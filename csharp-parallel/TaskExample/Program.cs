using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExample
{
    class Program
    {
        public static int Counter(int maxValue,int sleepDuration, CancellationToken token)
        {
            int counter;
            System.Console.WriteLine($"{Task.CurrentId} Initialized.");
            for(counter = 0; counter <= maxValue; counter++)
            {
                token.ThrowIfCancellationRequested();
                System.Console.WriteLine($"{Task.CurrentId}: Counter value = {counter}");
                Thread.Sleep(sleepDuration);
            }
            System.Console.WriteLine($"{Task.CurrentId}: Task Completed.");
            return counter;
        }
        static void Main(string[] args)
        {
            var source = new CancellationTokenSource();
            var source2 = new CancellationTokenSource();
            var counterTask = new Task<int>(() => Counter(10,3000,source.Token));
            var counter2Task = new Task<int>(() => Counter(15,1000,source2.Token));
            counterTask.Start();
            counter2Task.Start();
            try
            {
                Thread.Sleep(10000);
                source2.Cancel();
                Task.WaitAll(counterTask,counter2Task);
            }
            catch (AggregateException aggregateException)
            {
                foreach(var exception in aggregateException.InnerExceptions)
                {
                    System.Console.WriteLine($"Main: An {exception.GetType()} have been caught.");
                }
            }
            source.Dispose();
            source2.Dispose();
        }
    }
}
