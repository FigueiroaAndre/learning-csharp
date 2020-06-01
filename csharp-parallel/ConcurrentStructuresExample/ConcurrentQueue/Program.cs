using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ConcurrentQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("This program, as oppose to the one that have used a regular queue, should work fine in a multithreaded context.");
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            var cts = new CancellationTokenSource();
            var concurrentQueue = new ConcurrentQueue<int>();
            var token = cts.Token;
            var task1 = new Task( () => {
                int i = 0;
                while(true){
                    token.ThrowIfCancellationRequested();
                    concurrentQueue.Enqueue(i);
                    System.Console.WriteLine($"{i} enqueued!");
                    i++;
                }
            });

            var task2 = new Task(() => {
                while(true)
                {
                    token.ThrowIfCancellationRequested();
                    int dequeued;
                    concurrentQueue.TryDequeue(out dequeued);
                    System.Console.WriteLine($"{dequeued} dequeued!");
                }
            });

            task1.Start();
            task2.Start();
            try
            {
                task2.Wait();
            }
            catch (Exception e)
            {
                cts.Cancel();
                System.Console.WriteLine("An error has ocurred, the cancelation token cancelled all the Tasks!");
                System.Console.WriteLine($"ERROR: {e.GetType()} - {e.Message}");

            }
            finally
            {
                task1.Dispose();
                task2.Dispose();
            }

            System.Console.WriteLine("Main Done!");
            Console.ReadKey();
        }
    }
}
