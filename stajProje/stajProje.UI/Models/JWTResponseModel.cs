namespace stajProje.UI.Models
{
    public class JWTResponseModel
    {
        public string Token {  get; set; }
        public DateTimeOffset ExpireDate { get; set; }
    }
}
