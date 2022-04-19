using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake.Contracts
{
    public interface IPoint
    {
        public int LeftX { get; set; }
        public int TopY { get; set; }
        void Draw(char symbol);
        void Draw(int leftX, int topY, char symbol);
    }
}
