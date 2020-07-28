using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeginPatten
{
    class VisitorPattern2
    {
    }

    public interface ICarElement
    {
        void Accept(ICarVisitor visitor);
    }


    public interface ICarVisitor
    {
        void Visit(Engine element);
        void Visit(Body element);
        void Visit(Wheel element);
        void Visit(Car element);
    }

    public class Engine : ICarElement
    {
        public string Spec => "V4";
        public void Accept(ICarVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Body : ICarElement
    {
        public string Color => "Silver";
        public void Accept(ICarVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Wheel : ICarElement
    {
        public string Type => "P26";
        public void Accept(ICarVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class CarPrintVisitor : ICarVisitor
    {
        public void Visit(Engine element)
        {
            Console.WriteLine(element.Spec);
        }

        public void Visit(Body element)
        {
            Console.WriteLine(element.Color);
        }

        public void Visit(Wheel element)
        {
            Console.WriteLine(element.Type);
        }

        public void Visit(Car element)
        {
            Console.WriteLine(element.Maker);
        }
    }








    public class Car : ICarElement
    {
        public string Maker => "BMW";
        private List<ICarElement> elements;
        public Car()
        {
            elements = new List<ICarElement>
            {
                new Engine(),
                new Body(),
                new Wheel()
            };
        }

        public void Accept(ICarVisitor visitor)
        {
            foreach (var elem in elements)
            {
                elem.Accept(visitor);
            }
            visitor.Visit(this);
        }
    }

    class VisitorClient
    {
        public static void HowToTest()
        {
            ICarElement car = new Car();
            ICarVisitor visitor = new CarPrintVisitor();
            car.Accept(visitor);
        }
    }
}
