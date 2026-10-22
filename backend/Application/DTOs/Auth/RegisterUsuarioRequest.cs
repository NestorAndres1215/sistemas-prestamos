using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Auth;

public class RegisterUsuarioRequest
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
