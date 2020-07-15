using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeginPatten
{
    public class MyConnection
    {
        public MyConnection()
        {

        }
    }

    public class MyConnectionPool
    {
        private readonly ConcurrentBag<MyConnection> pool = new ConcurrentBag<MyConnection>();

        public MyConnection GetObject()
        {
            MyConnection obj;
            if(pool.TryTake(out obj))
            {
                return obj;
            }
            else
            {
                return new MyConnection();
            }
        }

        public void ReleaseObject(MyConnection conn)
        {
            pool.Add(conn);
            Debug.WriteLine($"Release: {conn.GetHashCode()}");
        }
    }

    class Client5
    {
        public static void HowToUse()
        {
            var myPool = new MyConnectionPool();
            MyConnection conn = myPool.GetObject();
            myPool.ReleaseObject(conn);

            MyConnection conn2 = myPool.GetObject();
            myPool.ReleaseObject(conn2);
        }
    }
    ////////////////////////////////////////////////////////////////////////

    class ObjectpollPattern
    {
       public ObjectpollPattern()
        {
            ThreadPool.QueueUserWorkItem(Calc);
            ThreadPool.QueueUserWorkItem(Calc, 10.0);
            ThreadPool.QueueUserWorkItem(Calc, 20.0);

            Console.ReadLine();
            
        }
        static void Calc(object radius)
        {
            if (radius == null)
            {
                return;
            }
            double r = (double)radius;
            double area = r * r * 3.14;
            Console.WriteLine("r={0}, area={1}", r, area);
        }
    }
}
