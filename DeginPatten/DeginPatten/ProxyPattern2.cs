using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DeginPatten
{
    class ProxyPattern2
    {
    }
    public interface IWeb
    {
        string Visit(string url);
    }
    public class ProxyWeb : IWeb
    {
        private IWeb realWeb = new RealWeb();

        List<string> BAD_SITES = new List<string>
        {
            "hackersite.com",
            "fraudsite.com",
            "phishinsite.com"

        };

        public string Visit(string url)
        {
            if (BAD_SITES.Contains(url)){
                return null;
            }
            return realWeb.Visit(url);
        }
    }

    public class RealWeb : IWeb
    {
        public string Visit(string url)
        {
            var wc = new WebClient();
            return wc.DownloadString(url);
        }
    }

    class Client2
    {
        public static void HowToTest()
        {
            IWeb web = new ProxyWeb();
            string result = web.Visit("http://fraydsite.com");
            Console.WriteLine(result);
        }
    }
}
