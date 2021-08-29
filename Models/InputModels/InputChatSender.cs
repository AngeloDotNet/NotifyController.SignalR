using System.ComponentModel.DataAnnotations;

namespace NotifyController_SignalR.Models.InputModels
{
    public class InputChatSender
    {
        [Required(ErrorMessage = "L'utente è obbligatorio"), Display(Name = "Utente")]
        public string user { get; set; }

        [Required(ErrorMessage = "Il messaggio è obbligatorio"), Display(Name = "Messaggio")]
        public string message { get; set; }
    }
}