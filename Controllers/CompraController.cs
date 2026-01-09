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
        var compra = await _service.CriarAsync(dto);
        return Ok(compra);
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        return Ok(await _service.ListarAsync());
    }

    [HttpGet("ultima")]
    public async Task<IActionResult> ListarUltima()
    {
        return Ok(await _service.ListarUltimaAsync());
    }
}
