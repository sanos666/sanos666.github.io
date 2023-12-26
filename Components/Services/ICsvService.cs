using OMH_Player_Cards.Components.Entities;

namespace OMH_Player_Cards.Components.Services
{
    public interface ICsvService
    {
        void Init();
        List<PlayerBio> GetPlayerBios();
        PlayerStat SelectPlayer(string playerName);
        List<PlayerStat> GetPlayers();
    }
}
