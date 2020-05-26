using System;

namespace Exercise1
{
    public class SendMail : IActivity
    {
        public void Execute()
        {
            System.Console.WriteLine("Sending Mail...");
        }
    }
}