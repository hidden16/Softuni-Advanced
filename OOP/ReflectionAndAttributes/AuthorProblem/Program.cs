using System;

namespace AuthorProblem
{
    [Author("Victor")]
    public class StartUp
    {
        [AuthorAttribute("George")]
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
