using Application.DTOs.Usuario;
using Application.Ports.Inbound;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/usuarios")]
public class UsuarioController : Controller
{
    private readonly UsuarioUseCase _usecase;

    public UsuarioController(UsuarioUseCase usecase)
    {
        _usecase = usecase;
    }


    [HttpPost("registro")]
    public async Task<IActionResult> Register(RegistroUsuarioRequest dto)
    {
        var result = await _usecase.Register(dto);
        return Ok(result);
    }


}
