﻿using ConsoleSnake.Contracts;
using ConsoleSnake.Enums;
using ConsoleSnake.SnakeFoods;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleSnake.Core
{
    public class Engine : IEngine
    {
        private Point[] pointsOfDirection;
        private Snake snake;
        private Wall wall;
        private Directions direction;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            pointsOfDirection = new Point[4];
        }
        public void Run()
        {
            CreateDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = this.snake.IsMoving(pointsOfDirection[(int)direction]);
                if (!isMoving)
                {
                    AskUserForRestart();
                }

                Thread.Sleep(150);
            }
        }
        private void AskUserForRestart()
        {
            int leftX = wall.LeftX + 1;
            int topY = 3;
            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n");
            string input = Console.ReadLine();
            if (input == "y")
            {
                Console.Clear();
                Environment.Exit(0);
            }
            else
            {
                StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game over!");
            Environment.Exit(0);
        }

        private void CreateDirections()
        {
            pointsOfDirection[0] = new Point(1, 0);
            pointsOfDirection[1] = new Point(-1, 0);
            pointsOfDirection[2] = new Point(0, 1);
            pointsOfDirection[3] = new Point(0, -1);
        }
        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();
            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Directions.Right)
                {
                    direction = Directions.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (direction != Directions.Left)
                {
                    direction = Directions.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (direction != Directions.Down)
                {
                    direction = Directions.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (direction != Directions.Up)
                {
                    direction = Directions.Down;
                }
            }
            Console.CursorVisible = false;
        }
    }
}
