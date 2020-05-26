using System;

namespace Exercise1
{
    public class VideoProcessor : IActivity
    {
        public void Execute()
        {
            System.Console.WriteLine("Processing Video...");
        }
    }
}