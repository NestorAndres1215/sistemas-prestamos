using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Common;
using Application.Models;
using Domain.Entities;

namespace Application.Ports.Outbound;

public interface IUsuarioRepository
{

    Task<UsuarioModel> AddAsync(UsuarioModel usuario);

}
