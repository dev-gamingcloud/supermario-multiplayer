using System.Linq;

namespace gamingCloud.Network
{

    [System.Serializable]
    public class RoomSetting
    {
        public string name = null;
        public bool isPrivate = false;
        public int? maxPlayers = null;

        public RoomSetting() { }

        public RoomSetting(int maxPlayersInRoom)
        {
            this.maxPlayers = maxPlayersInRoom;
        }
        public RoomSetting(string name, bool isPrivate)
        {
            this.name = name;
            this.isPrivate = isPrivate;
        }

        public RoomSetting(string name, bool isPrivate, int maxPlayersInRoom)
        {
            this.name = name;
            this.isPrivate = isPrivate;
            this.maxPlayers = maxPlayersInRoom;
        }

    }
}