using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Chat_SignalR.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<ChatHub> signalR;

        public HomeController(IHubContext<ChatHub> signalR)
        {
            this.signalR = signalR;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Benvenuto!";
            await signalR.Clients.All.SendAsync("ReceiveMessage", "Server", "Prova messaggio !");
            return View();
        }
    }
}