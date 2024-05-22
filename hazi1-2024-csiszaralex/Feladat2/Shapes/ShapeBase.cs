using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal abstract class ShapeBase : IShape
    {
        protected double x;
        protected double y;

        public ShapeBase(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public abstract double GetArea();
        public double GetX() => x;
        public double GetY() => y;

        public virtual string GetTypeName()
        {
            return "ShapeBase";
        }
    }
}
