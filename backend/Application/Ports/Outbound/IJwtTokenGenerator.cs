using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Ports.Outbound;

public interface IJwtTokenGenerator
{
    string GenerateToken(int userId, string email, string role);
}
