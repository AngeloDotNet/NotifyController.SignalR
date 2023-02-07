namespace NotifyController_SignalR.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController
{
    private readonly IHubContext<ChatHub> signalR;

    public ChatController(IHubContext<ChatHub> signalR)
    {
        this.signalR = signalR;
    }

    [HttpPost]
    public async Task SendServerMessage([FromForm] InputChatSender model)
    {
        await signalR.Clients.All.SendAsync("ReceiveMessage", model.user, model.message);
    }
}