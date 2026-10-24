using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Ports.Outbound;

public interface JwtTokenGeneratorPort
{
    string GenerateToken(int userId, string email);
}
