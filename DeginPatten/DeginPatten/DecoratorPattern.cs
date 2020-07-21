using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeginPatten
{
    class DecoratorPattern
    {
    }
    public abstract class Shape
    {
        public abstract void Draw(Graphics g);
        
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Circle : Shape
    {
        public Circle(Point origin, int radius)
        {
            X = origin.X;
            Y = origin.Y;
            Width = radius * 2;
            Height = radius * 2;
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(Pens.Black, X, Y, Width, Height);
        }
    }

    public abstract class ShapeDecorator : Shape
    {
        protected Shape component;
        public ShapeDecorator(Shape shape)
        {
            component = shape;
        }
    }

    public class FillShapeDecorator : ShapeDecorator
    {
        public FillShapeDecorator(Shape shape)
            :base(shape)
        {
            
        }

        public override void Draw(Graphics g)
        {
            component.Draw(g);

            g.FillEllipse(Brushes.Green, component.X, component.Y, component.Width, component.Height);
        }
    }
    class Decorator_Client
    {
        public static void HowToTest()
        {
            //Form form = new System.Windows.Forms.Form(); //윈폼 프레임워크에서
            //form.Show();
            //Graphics gr = form.CreateGraphics();

            //Shape shape = new Circle(new Point(100, 100), 50);
            //var deco = new FillShapeDecorator(shape);
            //deco.Draw(gr);
        }
    }
}
