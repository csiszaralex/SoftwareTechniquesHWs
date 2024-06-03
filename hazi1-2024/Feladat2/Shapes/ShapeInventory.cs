using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class ShapeInventory
    {
        private List<IShape> shapes = new List<IShape>();

        public void AddShape(IShape shape)
        {
            shapes.Add(shape);
        }

        public void ListAll()
        {
            foreach (IShape shape in shapes)
            {
                Console.WriteLine($"{shape.GetTypeName()} at ({shape.GetX()}, {shape.GetY()}) has area {shape.GetArea()}");
            }
        }   
    }
}
