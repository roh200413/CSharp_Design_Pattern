using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeginPatten
{
    class StrategyPattern
    {
    }

    class Context
    {
        public IAlgorithm Algorithm { get; set; }
    }
    interface IAlgorithm   
    {
        void Execute();
    }

    class AlgorithmA : IAlgorithm
    {
        public void Execute()
        {

        }
    }

    class AlorithmB : IAlgorithm
    {
        public void Execute()
        {

        }
    }

///////////////////////////////////////////////////////////

    public interface IPayment
    {
        void Pay(int amount);
    }

    public class CardPayment: IPayment
    {
        private string cardNo, mmyy;

        public CardPayment(string cardNo, string mmyy)
        {
            this.cardNo = cardNo;
            this.mmyy = mmyy;
        }

        public void Pay(int amount)
        {
            Console.WriteLine($"Charged {amount} tp {cardNo}");
        }
    }
    public class BitcoinPayment : IPayment
    {
        private string address;

        public BitcoinPayment(string address)
        {
            this.address = address;
        }

        public void Pay(int amount)
        {
            decimal btc = (decimal)(amount / 10000000.0);
            Console.WriteLine($"Charged {btc} to {address}");
        }
    }

    public class Checkout
    {
        public IPayment Payment { get; set; }

        public Checkout(IPayment payment)
        {
            this.Payment = payment;
        }

        public void Charge(int total)
        {
            Console.WriteLine($"Charging {total}");
            this.Payment.Pay(total);
        }
    }

    class StrategPatternClient
    {
        public static void HowToTest()
        {
            var card = new CardPayment("41111", "12/25");
            var chkout = new Checkout(card);
            chkout.Charge(20000);

            var btc = new BitcoinPayment("1qqwedfmln123iuj8a");
            chkout.Payment = btc;
            chkout.Charge(30000);
        }
    }
}
