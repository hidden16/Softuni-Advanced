using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    public class FoodAsteriks : Food
    {
        private const char symbol = '*';
        private const int points = 1;
        public FoodAsteriks(Wall wall) : base(wall, symbol, points)
        {
        }
    }
}
