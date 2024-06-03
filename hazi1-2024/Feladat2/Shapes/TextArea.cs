using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class TextArea : Controls.Textbox, IShape
    {
        public TextArea(int x, int y, int w, int h) : base(x, y, w, h) { }

        public double GetArea()
        {
            return base.GetWidth() * base.GetHeight();
        }

        public string GetTypeName()
        {
            return "TextArea";
        }

        double IShape.GetX()
        {
            return base.GetX();
        }

        double IShape.GetY()
        {
            return base.GetY();
        }
    }
}
