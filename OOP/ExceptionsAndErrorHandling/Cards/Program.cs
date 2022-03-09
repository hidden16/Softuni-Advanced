using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cards = new List<Card>();
            var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string[] faces = new string[]
            {
                "2","3","4","5","6","7","8","9","10","J","Q","K","A"
            };
            string[] suits = new string[]
            {
                "S","H","D","C"
            };
            foreach (var item in input)
            {
                try
                {
                    var splittedCards = item.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var face = splittedCards[0];
                    var suit = splittedCards[1];
                    if (faces.Contains(face) && suits.Contains(suit))
                    {
                        Card card = new Card(face, suit);
                        cards.Add(card);
                        continue;
                    }
                    throw new ArgumentException();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Invalid card!");
                }
            }
            Console.WriteLine(string.Join(" ",cards));
        }
    }
    class Card
    {
        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }
        public string Face { get; set; }
        public string Suit { get; set; }
        public override string ToString()
        {
            if (Suit == "S")
            {
            return $"[{Face}\u2660]";
            }
            else if (Suit == "H")
            {
                return $"[{Face}\u2665]";
            }
            else if (Suit == "D")
            {
               return $"[{Face}\u2666]";
            }
            else if (Suit == "C")
            {
                return $"[{Face}\u2663]";
            }
            return null;
        }
    }
}
