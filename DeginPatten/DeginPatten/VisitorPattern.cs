using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeginPatten
{
    class VisitorPattern
    {
    }

    public interface Element
    {
        void Accept(Visitor visitor);
    }
    public class ConcreteElementA : Element
    {
        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class ConcreteElementB : Element
    {
        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public interface Visitor
    {
        void Visit(ConcreteElementA element);
        void Visit(ConcreteElementB element);
    }

    public class ConcreteVisitor : Visitor
    {
        public void Visit(ConcreteElementA element)
        {
            Console.WriteLine(element.ToString());
        }

        public void Visit(ConcreteElementB element)
        {
            Console.WriteLine(element.ToString());
        }
    }
}
