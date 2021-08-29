using System.Net;
using System.Threading.Tasks;
using Chat_SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NotifyController_SignalR.Models.InputModels;

namespace NotifyController_SignalR.Controllers
{
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
        public async Task<string> SendServerMessage([FromForm] InputChatSender model)
        {
            HttpStatusCode result = await PublishMessage(model.user, model.message);
            if (result == HttpStatusCode.OK)
            {
                return result.ToString();
            }
            else
            {
                result = HttpStatusCode.InternalServerError;
                return result.ToString();
            }
        }

        public async Task<HttpStatusCode> PublishMessage(string user, string message)
        {
            try
            {
                await signalR.Clients.All.SendAsync("ReceiveMessage", user, message);
                return HttpStatusCode.OK;
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}