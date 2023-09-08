namespace Web_Labb1_MVC.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; } //Tog bort nullable. Borde funka lika bra :P

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}