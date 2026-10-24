
using Application.Ports.Outbound;

namespace Infrastructure.Auth;

public class PasswordHasher : PasswordHasherPort
{
    public string Hash(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);

    public bool Verify(string password, string hash)
    {
        if (string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(hash))
        {
            return false;
        }

        try
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
        catch (ArgumentException)
        {
            return false;
        }
    }
}
