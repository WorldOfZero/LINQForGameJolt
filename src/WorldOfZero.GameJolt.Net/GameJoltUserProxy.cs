using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfZero.GameJolt.Net
{
    public class GameJoltUserProxy
    {
        private string apiEndpoint = "http://gamejolt.com/api/game/v1/";
        private string action = "users";

        public string GetUsers(string gameId, string privateKey, params string[] usernames)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(apiEndpoint);
            builder.Append(action);
            builder.Append("?game_id=");
            builder.Append(gameId);
            builder.Append("&username=");
            for (int i = 0; i < usernames.Length; ++i)
            {
                builder.Append(usernames[i]);
                if (i != usernames.Length - 1)
                {
                    builder.Append(",");
                }
            }
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
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
