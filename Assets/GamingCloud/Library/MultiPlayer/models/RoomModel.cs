using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace gamingCloud.Network
{
    [System.Serializable]
    public class RoomModel
    {
        [ShowOnly] public string id;
        [ShowOnly] public string name;
        [ShowOnly] public int? maxPlayers;
        [ShowOnly] public bool isPrivate;
        public List<PlayerModel> players;
        public PlayerModel roomCreator;
        public JObject data;
    }
}