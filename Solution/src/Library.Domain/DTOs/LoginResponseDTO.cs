namespace Library.Domain.DTOs
{
    public class LoginResponse
    {
        public required string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
