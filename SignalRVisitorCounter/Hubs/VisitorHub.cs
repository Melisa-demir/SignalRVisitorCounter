using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace SignalRVisitorCounter.Hubs
{
    public class VisitorHub : Hub
    {
        private static int _visitorCount = 0;
        public override async Task OnConnectedAsync()
        {
            _visitorCount++;
            await Clients.All.SendAsync("VisitorCountChanged", _visitorCount);

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            _visitorCount--;
            await Clients.All.SendAsync("visitorCountChanged", _visitorCount);

            await base.OnDisconnectedAsync(exception);
        }
    }
}
