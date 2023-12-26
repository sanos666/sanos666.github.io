using Microsoft.AspNetCore.SignalR;
using OMH_Player_Cards.Components.Entities;

namespace OMH_Player_Cards.Components.Hubs
{
    public class MessageHub : Hub
    {
        public async Task GetRequest(string request, string args)
        {
            await Clients.All.SendAsync("GetRequest", request, args);
        }

        public async Task SendPlayerNames(List<string> playerNames)
        {
            await Clients.All.SendAsync("PlayerNames", playerNames);
        }

        public async Task SendPlayer(PlayerStat player)
        {
            await Clients.All.SendAsync("SendPlayer", player);
        }
    }
}
