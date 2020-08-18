using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeginPatten
{
    class ChainOfResposibilityPattern
    {
    }

    public enum CommandType
    {
        CommandType1,
        CommandType2,
        CommandType3
    }

    public abstract class Handler
    {
        public Handler Next { get; set; }
        public abstract void Process(CommandType cmdType, string request);
    }
    public class ConcreteHandler1 : Handler
    {
        public override void Process(CommandType cmdType, string request)
        {
            if (cmdType == CommandType.CommandType1)
            {
                Console.WriteLine($"Handled in ConcreteHandler1");
            }
            else
            {
                this.Next.Process(cmdType, request);
            }
        }
    }

    public class ConcreteHandler2 : Handler
    {
        public override void Process(CommandType cmdType, string request)
        {
            if (cmdType == CommandType.CommandType1)
            {
                Console.WriteLine($"Handled in ConcreteHandler2");
            }
            else
            {
                this.Next.Process(cmdType, request);
            }
        }
    }
    public class ConcreteHandler3 : Handler
    {
        public override void Process(CommandType cmdType, string request)
        {
            if (cmdType == CommandType.CommandType1)
            {
                Console.WriteLine($"Handled in ConcreteHandler3");
            }
            else
            {
                this.Next.Process(cmdType, request);
            }
        }
    }

    class ChainOfResposibilityClient
    {
        public static void HowToUse()
        {
            var chainHead = BuildChain();
            chainHead.Process(CommandType.CommandType2, "data");
        }

        private static Handler BuildChain()
        {
            var c1 = new ConcreteHandler1();
            var c2 = new ConcreteHandler2();
            var c3 = new ConcreteHandler3();

            c1.Next = c2;
            c2.Next = c3;
            return c1;
        }
    }
}
