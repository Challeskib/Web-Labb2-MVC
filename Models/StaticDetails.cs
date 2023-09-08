namespace Web_Labb1_MVC.Models
{
    public static class StaticDetails
    {
        public static string BookApiBase { get; set; }


        public enum ApiType
        {
            GET, POST, PUT, DELETE
        }
    }
}
