namespace dtos.auth
{
    public class AuthResultDto
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}