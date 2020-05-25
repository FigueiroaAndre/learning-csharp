using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack();
            // System.Console.WriteLine(stack.Pop()); //invalid
            stack.Push(1);
            stack.Push(DateTime.Now);
            stack.Push("Cristiano Ronaldo is the 'GOAT'");
            // stack.Push(null);
            System.Console.WriteLine(stack.Pop());
            System.Console.WriteLine(stack.Pop());
            System.Console.WriteLine(stack.Pop());
            // System.Console.WriteLine(stack.Pop()); //invalid
        }
    }
}
