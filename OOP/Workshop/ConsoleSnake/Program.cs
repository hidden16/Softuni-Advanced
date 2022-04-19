using ConsoleSnake.Core;
using ConsoleSnake.SnakeFoods;
using System;
using System.Collections.Generic;

namespace ConsoleSnake
{
    public class Program
    {
        static void Main(string[] args)
        {
            Wall wall = new Wall(60, 20);
            Snake snake = new Snake(wall);
            Food food = new FoodHash(wall);
            Queue<Point> queue = new Queue<Point>();
            food.SetRandomPosition(queue);
            Engine engine = new Engine(wall, snake);
            engine.Run();
        }
    }
}
