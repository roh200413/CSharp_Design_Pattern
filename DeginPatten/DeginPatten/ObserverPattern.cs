using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace DeginPatten
{
    class ObserverPattern
    {
    }

    class Observer_Subject
    {
        private List<IObserver> observers = new List<IObserver>();

        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void NotifyObservers()
        {
            foreach (var o in observers)
            {
                o.Update();
            }
        }
    }

    interface IObserver
    {
        void Update();
    }

    class ObserverA : IObserver
    {
        public void Update()
        {
            //update ObserverA object
        }
    }

    class ObserverB : IObserver
    {
        public void Update()
        {
            //update ObserverB object
        }
    }




  ///////////////////////////////////////////////////////////////
  

    class ObserverSubject
    {
        public event EventHandler Changed;

        public ObserverSubject()
        {
            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(Changed != null)
            {
                Changed(this, EventArgs.Empty);
            }
        }
    }

    class Observer
    {
        private ObserverSubject subject = new ObserverSubject();
        private string status;

        public void Test()
        {
            subject.Changed += Subject_Changed;

            Thread.Sleep(5000);
        }

        private void Subject_Changed(object sender, EventArgs e)
        {
            status = "Subject updated at " + DateTime.Now;
            Debug.WriteLine(status);
        }
    }
}
