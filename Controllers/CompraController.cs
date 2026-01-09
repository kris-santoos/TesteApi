using ApiTeste.Domain;
using ApiTeste.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/compras")]
public class ComprasController : ControllerBase
{
    private readonly ICompraService _service;

    public ComprasController(ICompraService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(CriarCompraDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ErrorResponse(
                "Dados inválidos"
            ));
        }

        try
        {
            Compra compra = await _service.CriarAsync(dto);
            return StatusCode(201, compra);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ErrorResponse(
                "Erro ao criar compra",
                ex.Message
            ));
        }
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        try
        {
            List<Compra> compras = await _service.ListarAsync();
            return Ok(compras);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ErrorResponse(
                "Erro ao listar compras",
                ex.Message
            ));
        }
    }

    [HttpGet("ultima")]
    public async Task<IActionResult> ListarUltima()
    {
        try
        {
            Compra compra = await _service.ListarUltimaAsync();

            if (compra == null)
            {
                return NotFound(new ErrorResponse(
                    "Nenhuma compra encontrada"
                ));
            }

            return Ok(compra);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ErrorResponse(
                "Erro ao buscar última compra",
                ex.Message
            ));
        }
    }
}
