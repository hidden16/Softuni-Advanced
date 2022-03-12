using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor.Editors
{
    public class ConsoleEditor : Editor
    {
        public override void DrawShape(IShape shape)
        {
            Console.WriteLine(shape.Draw());
        }
    }
}
