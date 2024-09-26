using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using System.Text;

string broker = "zfeemqtt.eastus.cloudapp.azure.com";
int port = 41883;
string clientId = "Senac107";
string topic = "valdiclei/sensor";
string username = "Senac";
string password = "Senac";

var factory = new MqttFactory();

var mqttClient = factory.CreateMqttClient();

var options = new MqttClientOptionsBuilder()
    .WithTcpServer(broker, port) // MQTT broker address and port
    .WithCredentials(username, password) // Set username and password
    .WithClientId(clientId)
    .Build();

var connectResult = await mqttClient.ConnectAsync(options);
await mqttClient.SubscribeAsync(topic);

mqttClient.ApplicationMessageReceivedAsync += async e =>
{
    Console.WriteLine($"Received message: {Encoding.UTF8.GetString(e.ApplicationMessage.PayloadSegment)} at {DateTime.UtcNow}");

    var temperaturaString = e.ApplicationMessage.ConvertPayloadToString();

    //var response = JsonSerializer.Deserialize<Temperatura>(temperaturaString);

    //await Database.Gravar(e.ApplicationMessage.Payload, response);
};

while (true)
{
    if (connectResult.ResultCode == MqttClientConnectResultCode.Success)
    {
        try
        {
            //// Publish a message 3 times
            //for (int i = 0; i < 3; i++)
            //{
            //var message = new MqttApplicationMessageBuilder()
            //.WithTopic(topic)
            //.WithPayload($"Hello, MQTT! Message number {i}")
            //.WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce)
            //.WithRetainFlag()
            //.Build();

            //await mqttClient.PublishAsync(message);
            //}

            //// Unsubscribe and disconnect
            //await mqttClient.UnsubscribeAsync(topic);
            //await mqttClient.DisconnectAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
    else
    {
        Console.WriteLine($"Failed to connect to MQTT broker: {connectResult.ResultCode}");
    }
}