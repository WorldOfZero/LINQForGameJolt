using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldOfZero.GameJolt.Net;

namespace WorldOfZero.GameJolt.Demo.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationConfig appConfig = new ApplicationConfig();
            GameJoltTimeProxy proxy = new GameJoltTimeProxy();
            System.Console.WriteLine(proxy.GetTime(appConfig.GameId, appConfig.PrivateKey));
            System.Console.ReadLine();
        }
    }
}
