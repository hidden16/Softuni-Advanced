using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor.Editors
{
    public abstract class Drawer
    {
        public abstract void DrawShape(IShape shape);
    }
}
