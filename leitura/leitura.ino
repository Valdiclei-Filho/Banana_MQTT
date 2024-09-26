#include <ESP8266WiFi.h>       // Biblioteca específica para ESP8266
#include <PubSubClient.h>
#include <ArduinoJson.h>
#include <Adafruit_AHT10.h>

// Informações da rede WiFi
const char* ssid = "SENAC";
const char* password = "x1y2z3@snc";

// Informações do servidor MQTT
const char* mqtt_server = "zfeemqtt.eastus.cloudapp.azure.com";
const int mqtt_port = 41883;
const char* mqtt_user = "Senac";
const char* mqtt_password = "Senac";
const char* clientID = "Senac103";
const char* topic = "Senac/Banana/Entrada";  // Tópico onde serão publicados os dados

WiFiClient espClient;
PubSubClient client(espClient);
Adafruit_AHT10 aht;

Adafruit_Sensor *aht_humidity, *aht_temp;

// Função para conectar ao WiFi
void setup_wifi() {
  delay(10);
  Serial.println();
  Serial.print("Conectando a ");
  Serial.println(ssid);

  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }

  Serial.println("");
  Serial.println("WiFi conectado");
  Serial.println("Endereço IP: ");
  Serial.println(WiFi.localIP());
}

// Função callback, chamada quando uma mensagem é recebida
void callback(char* topic, byte* payload, unsigned int length) {
  Serial.print("Mensagem recebida [");
  Serial.print(topic);
  Serial.print("]: ");
  String msg;
  for (int i = 0; i < length; i++) {
    msg += (char)payload[i];
  }
  Serial.println(msg);

  // Processar o JSON recebido, se necessário
  DynamicJsonDocument doc(1024);
  deserializeJson(doc, msg);
  const char* command = doc["command"];

  if (strcmp(command, "get_data") == 0) {
    // Enviar os dados do sensor
    publish_sensor_data();
  }
}

// Função para reconectar ao broker MQTT
void reconnect() {
  while (!client.connected()) {
    Serial.print("Tentando conectar ao MQTT...");
    if (client.connect(clientID, mqtt_user, mqtt_password)) {
      Serial.println("conectado");
      client.subscribe(topic);  // Inscreve no tópico para receber mensagens
    } else {
      Serial.print("Falha, rc=");
      Serial.print(client.state());
      Serial.println(" Tentando novamente em 5 segundos...");
      delay(5000);
    }
  }
}

// Publica os dados do sensor no broker MQTT em formato JSON
void publish_sensor_data() {
  sensors_event_t humidity, temp;
  aht_humidity->getEvent(&humidity);
  aht_temp->getEvent(&temp);

  // Criar objeto JSON
  DynamicJsonDocument doc(1024);
  doc["temperature"] = temp.temperature;
  doc["humidity"] = humidity.relative_humidity;

  // Converter para string JSON
  String output;
  serializeJson(doc, output);

  // Publicar no tópico
  client.publish(topic, output.c_str());
}

void setup(void) {
  Serial.begin(115200);
  setup_wifi();
  client.setServer(mqtt_server, mqtt_port);  // Conecta ao servidor MQTT
  client.setCallback(callback);  // Configura a função callback

  if (!aht.begin()) {
    Serial.println("Falha ao encontrar o chip AHT10");
    while (1) {
      delay(10);
    }
  }

  aht_temp = aht.getTemperatureSensor();
  aht_humidity = aht.getHumiditySensor();
}

void loop() {
  if (!client.connected()) {
    reconnect();  // Reconectar se a conexão for perdida
  }
  client.loop();  // Mantém o loop de comunicação MQTT

  // Publicar dados do sensor a cada 10 segundos
  static unsigned long lastPublishTime = 0;
  if (millis() - lastPublishTime > 10000) {
    publish_sensor_data();
    lastPublishTime = millis();
  }
}
