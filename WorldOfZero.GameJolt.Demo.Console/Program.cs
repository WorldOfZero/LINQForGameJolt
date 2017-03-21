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
            var appConfig = new ApplicationConfig();
            var proxy = new GameJoltUserProxy();
            var service = new ServiceProxy();
            System.Console.WriteLine(GetUserInformation(appConfig, proxy, service));
            System.Console.ReadLine();
        }

        private static string GetUserInformation(ApplicationConfig appConfig, GameJoltUserProxy proxy, ServiceProxy service)
        {
            var task = service.Get(proxy.GetUsers(appConfig.GameId, appConfig.PrivateKey, "runewake2"));
            task.Wait();
            return task.Result;
        }
    }
}
