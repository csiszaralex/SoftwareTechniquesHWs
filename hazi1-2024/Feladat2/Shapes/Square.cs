using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class Square : ShapeBase
    {
        private double a;
        public Square(double x, double y, double a): base(x, y)
        {
            this.a = a;
        }

        public override double GetArea()
        {
            return a * a;
        }

        public override string GetTypeName()
        {
            return "Square";
        }
    }
}
