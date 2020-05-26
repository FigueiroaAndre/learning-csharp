using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            var workflow = new Workflow();
            workflow.Push(new SendMail());
            workflow.Push(new UploadVideo());
            workflow.Push(new VideoEncoding());
            workflow.Push(new VideoProcessor());

            var engine = new Engine(workflow);
            engine.Run();

        }
    }
}
