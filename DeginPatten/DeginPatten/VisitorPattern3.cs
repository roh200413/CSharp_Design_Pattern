using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeginPatten
{
    class VisitorPattern3
    {
    }

    class SQLVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            this.Visit(node.Left);

            switch (node.NodeType)
            {
                case ExpressionType.GreaterThanOrEqual:
                    Console.Write(" >= ");
                    break;
                case ExpressionType.LessThanOrEqual:
                    Console.Write(" <= ");
                    break;
                case ExpressionType.AndAlso:
                    Console.Write(" AND ");
                    break;
            }

            this.Visit(node.Right);

            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            Console.Write(node.Value);
            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            Console.Write(node.Member.Name);
            return node;
        }
    }

    class SQLVisitorClient
    {
        public static void Test()
        {
            Person kim = new Person
            {
                Name = "Kim",
                Age = 35
            };

            Expression<Func<Person, bool>> condition = p => p.Age >= 20 && p.Age <= 40;

            var visitor = new SQLVisitor();
            visitor.Visit(condition);
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
