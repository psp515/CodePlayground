using Microsoft.AspNetCore.SignalR;
using MQTTnet;
using MQTTnet.Client;

namespace SignalRxMQTT.DataCenter;

public class DataCenter
{
    public IList<string> ConnectedUsers { get; set; } = new List<string>();
    private IHubContext<UserHub, IMqttTransitionClient> _context;
    public string Name { get; set; }
    public IMqttClient Client { get; init; }

    public DataCenter(string name, 
        string host, 
        string username, 
        string password,
        IHubContext<UserHub, IMqttTransitionClient> hub)
    {
        _context = hub;
        Name = name;

        var options = new MqttClientOptionsBuilder()
            .WithClientId(name)
            .WithTcpServer(host, 8883)
            .WithCredentials(username, password)
            .WithTls()
            .Build();

        Client = new MqttFactory().CreateMqttClient();

        Client.ConnectAsync(options).Wait();
        Client.ApplicationMessageReceivedAsync += Client_ApplicationMessageReceivedAsync;

        Client.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic("topic").Build()).Wait();
    }

    private async Task Client_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs args)
    {
        foreach (var user in ConnectedUsers)
        {
            await _context
                .Clients
                .Client(user)
                .Message(Name, args.ApplicationMessage.Topic, args.ApplicationMessage.ConvertPayloadToString());
        }
    }


    public async Task SendMessage(string topic, string message)
    {
       await Client.PublishAsync(new MqttApplicationMessageBuilder()
            .WithTopic(topic)
            .WithPayload(message)
            .Build());
    }
}

