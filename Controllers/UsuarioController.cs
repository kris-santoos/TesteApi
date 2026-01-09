using ApiTeste.Domain;
using ApiTeste.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/usuarios")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _service;

    public UsuariosController(IUsuarioService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(CriarUsuarioDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ErrorResponse(
                "Dados inválidos"
            ));
        }

        try
        {
            Usuario usuario = await _service.CriarAsync(dto);
            return StatusCode(201, usuario);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ErrorResponse(
                "Erro ao criar usuário",
                ex.Message
            ));
        }
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        try
        {
            List<Usuario> usuarios = await _service.ListarAsync();
            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ErrorResponse(
                "Erro ao listar usuários",
                ex.Message
            ));
        }
    }
}
