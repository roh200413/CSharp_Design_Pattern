using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
