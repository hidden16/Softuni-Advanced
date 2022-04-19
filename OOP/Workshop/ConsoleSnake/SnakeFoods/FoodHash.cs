﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake.SnakeFoods
{
    public class FoodHash : Food
    {
        private const char symbol = '#';
        private const int points = 3;
        public FoodHash(Wall wall) : base(wall, symbol, points)
        {
        }
    }
}
