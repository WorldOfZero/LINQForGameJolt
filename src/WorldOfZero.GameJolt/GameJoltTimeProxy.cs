using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldOfZero.GameJolt
{
    public class GameJoltTimeProxy
    {
        private string apiEndpoint = "http://api.gamejolt.com/api/game/v1_2/";
        private string action = "get-time/";

        public string GetTime(string gameId, string privateKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(apiEndpoint);
            builder.Append(action);
            builder.Append("?game_id");
            builder.Append(gameId);
            return builder.ToString();
        }
    }
}
