using Microsoft.AspNetCore.SignalR;
using SignalRxMQTT.DataCenter;

namespace SignalRxMQTT;

public class UserHub : Hub<IMqttTransitionClient>
{
    DataCenterArray DataCenter;
    public UserHub(DataCenterArray dataCenter)
    {
        DataCenter = dataCenter;
    }

    public override async Task OnConnectedAsync()
    {
        await Clients
            .Client(Context.ConnectionId)
            .WelcomeRequest("Successfully established connection with Hub");
        
        await base.OnConnectedAsync();
    }

    public async Task GetMessage(string provider, string topic, string message)
    {
        // got message from client
        Console.WriteLine($"Got message for {provider} on topic {topic}: {message}");
        var dc = DataCenter.GetDataCenter(provider);

        if (dc.ConnectedUsers.Contains(Context.ConnectionId))
        {
            await dc.SendMessage(topic, message);
        }
    }

    public async Task Connect(string provider)
    {
        // got message from client
        Console.WriteLine($"Got message for {provider}");

        var dc = DataCenter.GetDataCenter(provider);
        dc.ConnectedUsers.Add(Context.ConnectionId);
    }
}

public interface IMqttTransitionClient
{
    Task WelcomeRequest(string welcome);
    Task Connect(string provider);
    Task Message(string provider, string topic, string message);
}