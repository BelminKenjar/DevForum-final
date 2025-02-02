using DevForum.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace DevForum.Hubs
{
    public class MessageHub : Hub
    {
        public async Task NewMessage(Message message)
        {
            await Clients.All.SendAsync("MessageReceived", message);
        }
    }
}
