using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace DeginPatten
{
    class SingletonPattern2
    {
    }

    public sealed class Configuration
    {
        public static Configuration Settings { get; } = new Configuration();

        private Dictionary<String, object> dict = new Dictionary<string, object>();

        private Configuration()
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            var str = File.ReadAllText("Config.json");
            JObject jo = JObject.Parse(str);

            foreach (var kv in jo)
            {
                dict.Add(kv.Key, kv.Value);
            }
        }

        public object this[string key]
        {
            get
            {
                return dict[key];
            }
        }
    }

    class Client4
    {
        public static void HowToTest()
        {
            var user = Configuration.Settings["Username"];
            var server = Configuration.Settings["Server"];
            Console.WriteLine($"{server},{user}");
        }
    }
}
