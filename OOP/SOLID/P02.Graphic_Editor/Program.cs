using P02.Graphic_Editor.Editors;
using P02.Graphic_Editor.Models;
using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape shape = new Circle();
            Drawer editor = new ConsoleDrawer();
            editor.DrawShape(shape);
            shape = new Triangle();
            editor.DrawShape(shape);
            shape = new Rectangle();
            editor.DrawShape(shape);
            shape = new Square();
            editor.DrawShape(shape);
        }
    }
}
