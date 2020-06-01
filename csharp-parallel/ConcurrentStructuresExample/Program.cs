using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentStructuresExample
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("This program is expected to raise an error!");
            System.Console.WriteLine("Ordinary collections were not meant to work with multithreading");
            System.Console.WriteLine("At some point, the dequeue task will try to dequeue an value that haven't been enqueued yet! Looking for the last dequeue print in this execution.");
            System.Console.Write("Press any key to continue...");
            Console.ReadKey();
            var cts = new CancellationTokenSource();
            var consolePadlock = new object();
            var queue = new Queue<int>();
            var token = cts.Token;
            var task1 = new Task(() => {
                int i = 0;
                while(true){
                    token.ThrowIfCancellationRequested();
                    queue.Enqueue(i);
                    System.Console.WriteLine($"{i} enqueued!");
                    i++;
                }
            });

            var task2 = new Task(() => {
                while(true)
                {
                    token.ThrowIfCancellationRequested();
                    int dequeued = queue.Dequeue();
                    System.Console.WriteLine($"{dequeued} dequeued!");
                }
            });

            task1.Start();
            Thread.Sleep(1);
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
