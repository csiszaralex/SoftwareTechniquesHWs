using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class Circle : ShapeBase
    {
        private double r;

        public Circle(double x, double y, double r): base(x, y)
        {
            this.r = r;
        }
        public override double GetArea()
        {
            return Math.PI * r * r;
        }
        public override string GetTypeName()
        {
            return "Circle";
        }
    }
}
