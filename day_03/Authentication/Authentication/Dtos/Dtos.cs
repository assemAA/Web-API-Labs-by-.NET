namespace Authentication.Dtos
{
    public record LoginDto(string UserName, string Password);
    public record TokenDto(string Token, DateTime Expiry);

    public record RegisterDto(string UserName,
        string Email,
        string Password,
        string Address);

    public class Dtos
    {
    }
}
