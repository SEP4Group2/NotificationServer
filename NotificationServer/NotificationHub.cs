using System.Collections.Concurrent;
using Microsoft.AspNetCore.SignalR;

namespace NotificationServer;

public class NotificationHub : Hub
{
    
    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync( "ReceiveNotification",$"{Context.ConnectionId} Someone Joined");
        
        Console.WriteLine("Connection new");
    }
    
    public async void AddToGroup(string userId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, userId);
        await Clients.All.SendAsync( "ReceiveNotification",$"{Context.ConnectionId} is in the group");
    }

    public async void RemoveFromGroup(string userId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
        await Clients.All.SendAsync( "ReceiveNotification",$"{Context.ConnectionId} left the group");
    }

    
}