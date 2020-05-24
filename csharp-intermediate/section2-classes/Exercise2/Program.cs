using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            string postTitle = "Learning Intermediate C#";
            string postDescription = "I'm learning C# because i've started as an intern in a project that uses ASP.NET Core at the backend! Next course: Advanced!!";
            var post = new Post(postTitle,postDescription);

            //This time i've chosed not to make an interactive menu, so i could move forward faster
            //I'll like it 3 times, then dislike it 4 times and then like it 8 times
            for (int i = 0; i < 3; i++) post.Like();
            for (int i = 0; i < 4; i++) post.Dislike();
            for (int i = 0; i < 8; i++) post.Like();

            Console.WriteLine("Like: {0}",post.UpVote); //should be 11
            // post.UpVote = 7; //should be Invalid
            Console.WriteLine("Dislike: {0}",post.DownVote); // should be 4
            // post.DownVote = 7; //should be Invalid
            Console.WriteLine("Created At: {0}",post.CreatedAt);
            // post.CreatedAt = DateTime.Now; //should be invalid
            post.Details();
        }
    }
}
