using MQTTnet;
using MQTTnet.Client;


// Configurações do cliente MQTT
var options = new MqttClientOptionsBuilder();

// Criação do cliente MQTT
var factory = new MqttFactory();
var mqttClient = factory.CreateMqttClient();

// Evento para receber as mensagens dos tópicos
mqttClient.UseApplicationMessageReceivedHandler(e =>
    {
        var payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
        Console.WriteLine($"Mensagem recebida no tópico {e.ApplicationMessage.Topic}: {payload}");
    });

// Evento de conexão
mqttClient.UseConnectedHandler(async e =>
{
    Console.WriteLine("Conectado ao broker MQTT.");

    // Assina o tópico
    await mqttClient.SubscribeAsync(new MQTTnet.Client.Subscribing.MqttClientSubscribeOptionsBuilder()
        .WithTopicFilter("meu/topico")
        .Build());

    Console.WriteLine("Inscrito no tópico 'meu/topico'.");
});

// Conecta ao broker
await mqttClient.ConnectAsync(options, System.Threading.CancellationToken.None);

// Aguarda para receber mensagens
Console.WriteLine("Aguardando mensagens... Pressione qualquer tecla para sair.");
Console.ReadLine();

// Desconecta ao sair
await mqttClient.DisconnectAsync();
