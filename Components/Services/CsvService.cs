
using OMH_Player_Cards.Components.Entities;

namespace OMH_Player_Cards.Components.Services
{
    public class CsvService : ICsvService
    {
        public List<PlayerStat> Players { get; set; }
        public PlayerStat SelectedPlayer { get; set; }

        public List<PlayerBio> GetPlayerBios()
        {
            return Players
                .Select(p => new PlayerBio { 
                    ID = p.ID,
                    Player = p.Player,
                    Team = p.Team
                })
                .ToList();
        }

        public PlayerStat SelectPlayer(string id)
        {
            SelectedPlayer = Players.FirstOrDefault(p => p.ID == id) ?? new PlayerStat();
            
            return SelectedPlayer;
        }        

        public void Init()
        {
            Players = Entities.CsvHelper.ReadCsvToPlayerStats();
        }

        public List<PlayerStat> GetPlayers()
        {
            return Players;
        }
    }
}
