using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WorldOfZero.GameJolt.Net
{
    public class GameJoltTimeProxy
    {
        private string apiEndpoint = "http://api.gamejolt.com/api/game/v1_2/";
        private string action = "time/";

        public string GetTime(string gameId, string privateKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(apiEndpoint);
            builder.Append(action);
            builder.Append("?game_id=");
            builder.Append(gameId);
            builder.Append("&format=json");
            var request = builder.ToString();
            var requestWithPrivateKey = request + privateKey;
            var hash = Hash(requestWithPrivateKey);
            var hashedResult = $"{request}&signature={hash}";
            return hashedResult;
        }

        private static string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}
