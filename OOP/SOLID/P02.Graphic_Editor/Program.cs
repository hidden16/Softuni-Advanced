using P02.Graphic_Editor.Models;
using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape shape = new Circle();
            GraphicEditor editor = new GraphicEditor();
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
