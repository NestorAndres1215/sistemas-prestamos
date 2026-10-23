using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Common;
using Application.DTOs.Usuario;
using Application.Models;

namespace Application.Ports.Inbound;

public interface UsuarioUseCase
{
    Task<UsuarioReponse> Register(RegistroUsuarioRequest request);

}
