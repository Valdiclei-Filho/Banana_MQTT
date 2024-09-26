using Banana.UI.Models;
using Banana.UI.Mqtt.Message;
using MQTTnet;
using MQTTnet.Client;
using System.Text;
using System.Text.Json;

namespace Banana.UI.Mqtt;

public class ConectarMqtt(IMessageService messageService)
{
    public async Task Conectar()
    {
        string broker = "zfeemqtt.eastus.cloudapp.azure.com";
        int port = 41883;
        string clientId = "Senac107";
        string topic = "Senac/Banana/Entrada";
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

            var response = JsonSerializer.Deserialize<LeituraModel>(temperaturaString);
            await Database.Gravar(response);


            messageService.SendMessage(response);

        };

    }
}
