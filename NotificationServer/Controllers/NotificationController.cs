using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NotificationServer;
using NotificationServer.Model;

namespace NotificationServer.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
    private readonly IHubContext<NotificationHub> _notificationHub;

    public NotificationController (IHubContext<NotificationHub> notificationHub)
    {
        _notificationHub = notificationHub;
    }
    
    //end point to be used by plant api to trigger a notification for front-end
    [HttpPost]
    [Route("send")]
    public async Task<IActionResult> SendNotification([FromBody] NotificationRequestDTO request)
    {
        try
        {
            await _notificationHub.Clients.Group(request.UserId).SendAsync("ReceiveNotification",request.Message);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
        
    }
}