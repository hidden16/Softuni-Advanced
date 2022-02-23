using System;
using System.Collections.Generic;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> queue = new Queue<string>(songs);
            List<string> forShow = new List<string>();
            while (queue.Count > 0)
            {
                var cmds = Console.ReadLine();
                if (cmds == "Play")
                {
                    queue.Dequeue();
                }
                else if (cmds.Contains("Add"))
                {
                    var token = cmds.Split("Add ",StringSplitOptions.RemoveEmptyEntries);
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
                else if (cmds == "Show")
                {
                    while (queue.Count > 0)
                    {
                        forShow.Add(queue.Dequeue());
                    }
                    Console.WriteLine(string.Join(", ",forShow));
                    for (int i = 0; i < forShow.Count; i++)
                    {
                        queue.Enqueue(forShow[i]);
                    }
                    forShow.Clear();
                }
            }
            Console.WriteLine($"No more songs!");
        }
    }
}
