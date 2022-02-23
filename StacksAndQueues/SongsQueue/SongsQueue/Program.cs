using System;
using System.Collections.Generic;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            var songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < songs.Length; i++)
            {
                queue.Enqueue(songs[i]);
            }
            while (queue.Count != 0)
            {
                var commands = Console.ReadLine();
                if (commands.Contains("Play"))
                {
                    queue.Dequeue();
                }
                else if (commands.Contains("Add"))
                {
                    var token = commands.Split("Add ",StringSplitOptions.RemoveEmptyEntries);
                    var song = token[0];
                    if (!queue.Contains(song))
                    {
                        queue.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (commands.Contains("Show"))
                {
                    List<string> printSongs = new List<string>();
                    foreach (var item in queue)
                    {
                        printSongs.Add(item);
                    }
                    Console.WriteLine(string.Join(", ", printSongs));
                }
            }
            if (queue.Count == 0)
            {
                Console.WriteLine($"No more songs!");
                return;
            }
        }
    }
}
