using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            string select;
            int control = 0;
            var stopwatch = new Stopwatch();

            while (control != 4)
            {
                System.Console.WriteLine("1. Start Stopwatch");
                System.Console.WriteLine("2. Stop Stopwatch");
                System.Console.WriteLine("3. Check Stopwatch Duration");
                System.Console.WriteLine("4.Exit");

                Console.Write("Input: ");
                select = Console.ReadLine();
                control = Convert.ToInt32(select);

                System.Console.Clear();
                switch(control){
                    case 1:
                        stopwatch.Start();
                        System.Console.WriteLine("Stopwatch successfully started!");
                        break;

                    case 2:
                        stopwatch.Stop();
                        System.Console.WriteLine("Stopwatch successfully stopped!");
                        break;

                    case 3:
                        System.Console.WriteLine("Duration: {0}", stopwatch.Duration);
                        break;

                    case 4:
                        break;

                    default:
                        System.Console.WriteLine("Invalid Option!");
                        break;
                }
                System.Console.WriteLine("========================");
            }
        }
    }
}
