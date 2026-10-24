
namespace Application.Ports.Outbound;

public interface PasswordHasherPort
{
    string Hash(string password);
    bool Verify(string password, string hash);
}
