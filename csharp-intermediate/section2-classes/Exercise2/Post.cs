using System;

namespace Exercise2
{
    class Post
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; private set; }
        public int UpVote { get; private set; }
        public int DownVote { get; private set; }

        public Post (string title, string description)
        {
            this.Title = title;
            this.Description = description;
            CreatedAt = DateTime.Now;
            UpVote = 0;
            DownVote = 0;
        }

        public void Like ()
        {
            UpVote++;
        }

        public void Dislike ()
        {
            DownVote++;
        }

        public void Details ()
        {
            Console.WriteLine("===============");
            Console.WriteLine("Title: {0}",Title);
            Console.WriteLine("Description: {0}",Description);
            Console.WriteLine("Created At: {0}",CreatedAt);
            Console.WriteLine("Like: {0}",UpVote);
            Console.WriteLine("Disike: {0}",DownVote);
            Console.WriteLine("===============");
        }
    }
}