using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeginPatten
{
    class ProxyPattern
    {
    }

    public interface Subject
    {
        void Operation();
    }

    public class RealSubject : Subject
    {
        public void Operation()
        {

        }
    }
    public class Proxy : Subject
    {
        private RealSubject realSubject;
        public Proxy()
        {
            realSubject = new RealSubject();
        }
        public void Operation()
        {
            realSubject.Operation();
        }
    }

    class Client1
    {
        void HowToUse()
        {
            Subject s = new Proxy();
            s.Operation();
        }
    }
}
