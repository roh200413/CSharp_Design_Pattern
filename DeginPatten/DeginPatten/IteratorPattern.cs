using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeginPatten
{
    class IteratorPattern
    {
    }

    public interface IAggregate
    {
        IIterator GetIterator();
    }
    public class ColorAggregate : IAggregate
    {
        object[] colors = { "White", "Red", "Green", "Blue", "Black" };

        public IIterator GetIterator()
        {
            return new CommonIterator(colors);
        }

        public int Count => colors.Length;
    }
    public interface IIterator
    {
        bool HasNext { get; }
        object Next();
    }

    class CommonIterator : IIterator
    {
        private object[] collection;
        private int index;

        public CommonIterator(object[] collection)
        {
            this.collection = collection;
            this.index = -1;
        }

        public bool HasNext
        {
            get
            {
                return index + 1 < collection.Length;
            }
        }

        public object Next()
        {
            if (HasNext)
            {
                index++;
                return collection[index];
            }
            else
            {
                return null;
            }
        }
    }

    class IteratorClient
    {
        public static void HowToTest()
        {
            IAggregate agg = new ColorAggregate();
            IIterator iter = agg.GetIterator();

            object c1 = iter.Next();
            object c2 = iter.Next();
            object c3 = iter.Next();

            Console.WriteLine("{0},{1},{2}", c1, c2, c3);
        }
    }
    
}
