using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeginPatten
{
    class CommandPattern
    {
    }

    //Invoker 클래스
    class User
    {
        private List<ICommand> _commands = new List<ICommand>();

        //Queue에 명령 객체 추가
        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }
        public void AddCommand(StockBroker broker, string symbol, TxType txType, int qty)
        {
            ICommand c = new StockCommand(broker, symbol, txType, qty);
            _commands.Add(c);
        }

        //Queue에 있는 명령들을 실행하도록 요청
        public void ExecuteAll()
        {
            foreach (var cmd in _commands)
            {
                cmd.Execute();
            }
        }
    }
    interface ICommand
    {
        void Execute();
    }

    class StockCommand : ICommand
    {
        private StockBroker _broker;
        private string symbol;
        private TxType txType;
        private int qty;

        public StockCommand(StockBroker broker, string symbol, TxType txType, int qty)
        {
            this._broker = broker;
            this.symbol = symbol;
            this.txType = txType;
            this.qty = qty;
        }
        public void Execute()
        {
            _broker.Process(symbol, txType, qty);
        }
    }
    enum TxType { Buy, Sell}

    class StockBroker
    {
        public void Process(string stockSymbol, TxType txType, int qty)
        {
            Console.WriteLine($"{txType.ToString()},{stockSymbol},{qty}");
        }
    }

    class Client
    {
        public static void HowToUse()
        {
            var broker = new StockBroker();

            User user = new User();
            ICommand c = new StockCommand(broker, "MSFT", TxType.Buy, 150);

            user.AddCommand(c);
            user.AddCommand(broker, "AMZN", TxType.Sell, 2000);

            user.ExecuteAll();
        }
    }
}
