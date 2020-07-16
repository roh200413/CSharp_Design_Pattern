using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeginPatten
{
    class AdapterPattern
    {
    }
    public class Adapter_Client
    {
        public void Operation()
        {
            Adapter adapter = new Adapter();
            adapter.Request();
        }
    }
    public class Adapter
    {
        private Adaptee adaptee = new Adaptee();

        public void Request()
        {
            adaptee.AdapteeRequest();
        }
    }

    public class Adaptee
    {
        public void AdapteeRequest()
        {

        }
    }
}
