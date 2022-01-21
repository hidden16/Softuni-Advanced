using System;
using System.Collections.Generic;
using System.Linq;

namespace TheV_Logger
{
    class Followage
    {
        private List<string> _followers = new List<string>();
        private List<string> _following = new List<string>();
        public List<string> Followers
        {
            get
            { return _followers;}
        }
        public List<string> Following
        {
            get
            { return _following; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Followage> vloggers = new Dictionary<string, Followage>();
            var input = Console.ReadLine();
            while (input != "Statistics")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input.Contains("joined"))
                {
                    var splitted = input.Split(" joined ", StringSplitOptions.RemoveEmptyEntries);
                    if (!vloggers.ContainsKey(splitted[0]))
                    {
                        var name = splitted[0];
                        vloggers.Add(name, new Followage());
                    }
                }
                if (tokens[1].ToLower() == "followed")
                {
                    var vloggerOne = tokens[0];
                    var vloggerTwo = tokens[2];
                    if (vloggerOne != vloggerTwo && vloggers.ContainsKey(vloggerOne) && vloggers.ContainsKey(vloggerTwo))
                    {
                        if (!vloggers[vloggerOne].Following.Contains(vloggerTwo))
                        {
                            vloggers[vloggerOne].Following.Add(vloggerTwo);
                            vloggers[vloggerTwo].Followers.Add(vloggerOne);
                        }
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"The V-Logger has a total of {vloggers.Keys.Count} vloggers in its logs.");
            var vloggerToRemove = "";
            foreach (var vlogger in vloggers.OrderByDescending(x=>x.Value.Followers.Count).ThenBy(x=>x.Value.Following.Count))
            {
                Console.WriteLine($"1. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");
                vloggerToRemove = vlogger.Key;
                foreach (var item in vlogger.Value.Followers.OrderBy(x=>x))
                {
                    Console.WriteLine($"*  {item}");
                }
                break;
            }
            vloggers.Remove(vloggerToRemove);
            var counter = 2;
            foreach (var item in vloggers.OrderByDescending(x=>x.Value.Followers.Count).ThenBy(x=>x.Value.Following.Count))
            {
                Console.WriteLine($"{counter}. {item.Key} : {item.Value.Followers.Count} followers, {item.Value.Following.Count} following");
                counter++;
            }
            
        }
    }
}
