using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleSnake.SnakeFoods
{
    public class Snake
    {
        private const char snakeSymbol = '\u25CF';
        private Queue<Point> snakeElements;
        private Food[] foods;
        private Wall wall;
        private int nextLeftX = 0;
        private int nextTopY = 0;
        private int foodIndex;
        private int RandomFoodNumber => new Random().Next(0, foods.Length);

        public Snake(Wall wall)
        {
            this.wall = wall;
            snakeElements = new Queue<Point>();
            foods = new Food[3];
            foodIndex = RandomFoodNumber;
            GetFoods();
            CreateSnake();
        }
        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                snakeElements.Enqueue(new Point(2, topY));
            }
        }
        private void GetFoods()
        {
            foods[0] = new FoodHash(this.wall);
            foods[1] = new FoodAsteriks(this.wall);
            foods[2] = new FoodDollar(this.wall);
        }
        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = snakeElements.Last();

            GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = snakeElements.Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }
            Point snakeNewHead = new Point(nextLeftX, nextTopY);
            if (wall.IsPointWall(snakeNewHead))
            {
                return false;
            }
            snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);

            if (foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                Eat(direction, currentSnakeHead);
            }

            Point snakeTail = snakeElements.Dequeue();
            snakeTail.Draw(' ');
            return true;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int lenght = foods[foodIndex].FoodPoints;

            for (int i = 0; i < lenght; i++)
            {
                snakeElements.Enqueue(new Point(nextLeftX, nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }
            foodIndex = RandomFoodNumber;
            foods[foodIndex].SetRandomPosition(snakeElements);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            nextLeftX = direction.LeftX + snakeHead.LeftX;
            nextTopY = direction.TopY + snakeHead.TopY;
        }

    }
}
