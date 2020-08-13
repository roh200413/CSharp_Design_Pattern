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

    class ChainOfResposibilityClient
    {

    }
}
