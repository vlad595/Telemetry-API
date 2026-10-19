using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.SignalR;
using Models;

namespace Hubs
{
    public class MainHub: Hub
    {
        public async Task EnterGroup(string serverId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, serverId);
        }
        public async Task LeaveGroup(string serverId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, serverId);
        }
        public async Task SendMetrics(string serverId, MachineMetrics metrics)
        {
            await Clients.GroupExcept(serverId, Context.ConnectionId).SendAsync("ReceiveMetrics", metrics);
        }
        public async Task PauseAgent(string serverId)
        {
            await Clients.GroupExcept(serverId, Context.ConnectionId).SendAsync("ReceiveOnPause");
        }
        public async Task RestoreAgent(string serverId)
        {
            await Clients.GroupExcept(serverId, Context.ConnectionId).SendAsync("ReceiveOnRestore");
        }
    }
}