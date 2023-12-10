using System.Collections.Concurrent;
using Microsoft.AspNetCore.SignalR;

namespace NotificationServer;

public class NotificationHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        Console.WriteLine("Connection new");
    }
    
    public async void AddToGroup(string userId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, userId);
        Console.WriteLine($"{Context.ConnectionId} is in the group");
    }
    
    public async void RemoveFromGroup(string userId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId); 
        Console.WriteLine($"{Context.ConnectionId} left the group");
    }
}