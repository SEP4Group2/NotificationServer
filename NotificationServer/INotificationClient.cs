namespace NotificationServer;

public interface INotificationClient
{
    Task ReceiveNotification(string message);
}