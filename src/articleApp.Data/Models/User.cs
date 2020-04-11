namespace articleApp.Data.Models
{
    public class User : MainModel
    {
        public byte UserType { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}