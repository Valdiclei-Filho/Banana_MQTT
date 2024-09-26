using Banana.UI.Models;

namespace Banana.UI.Mqtt.Message;

public interface IMessageService
{
    event Action<LeituraModel> OnMessage;

    void SendMessage(LeituraModel model);
    void Subscribe(Action<LeituraModel> handler);
}

public class MessageService : IMessageService
{
    public event Action<LeituraModel> OnMessage;

    public void SendMessage(LeituraModel model)
    {
        OnMessage?.Invoke(model);
    }

    public void Subscribe(Action<LeituraModel> handler)
    {
        OnMessage += handler;
    }
}
