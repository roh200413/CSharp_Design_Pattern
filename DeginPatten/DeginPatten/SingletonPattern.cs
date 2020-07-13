using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeginPatten
{
    class SingletonPattern
    {
    }
    public sealed class Singleton
    {
        public static readonly Singleton Instance = new Singleton();

        private Singleton() { }

        public void Method()
        {
            Console.WriteLine(".,..");
        }
    }

    class Client3
    {
        public static void HowToTest()
        {
            Singleton.Instance.Method();
        }
    }
}
