using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleSnake
{
    public abstract class Food : Point
    {
        private char foodSymbol;
        private Random random;
        private Wall wall;
        private int leftX;
        private int topY;
        public Food(Wall wall, char foodSymbol, int points) : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            FoodPoints = points;
            random = new Random();
        }
        public int FoodPoints { get; private set; }
        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            LeftX = random.Next(2, wall.LeftX - 2);
            TopY = random.Next(2, wall.TopY - 2);

            bool pointOnSnake = snakeElements.Any(x=>x.LeftX == this.LeftX && x.TopY == this.TopY);

            while (pointOnSnake)
            {
                LeftX = random.Next(2, wall.LeftX - 2);
                TopY = random.Next(2, wall.TopY - 2);
                leftX = LeftX;
                topY = TopY;
                pointOnSnake = snakeElements.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            }

            Console.BackgroundColor = ConsoleColor.Green;
            Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public bool IsFoodPoint(Point snake)
        {
            return snake.TopY == this.TopY && snake.LeftX == this.LeftX;
        }
    }
}
