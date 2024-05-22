namespace Shapes;

public class Program
{
    public static void Main(string[] args)
    {
        ShapeInventory sh = new ShapeInventory();

        sh.AddShape(new Circle(1, 2, 3));
        sh.AddShape(new Square(4, 5, 6));

        sh.AddShape(new Square(7, 8, 9));
        sh.AddShape(new Square(10, 11, 2));

        sh.AddShape(new TextArea(12, 13, 14, 15));
        sh.AddShape(new TextArea(1, 5, 3, 2));

        sh.ListAll();
    }
}
