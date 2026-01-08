using ApiTeste.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/produtos")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _service;

    public ProdutosController(IProdutoService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(CriarProdutoDto dto)
    {
        var produto = await _service.CriarAsync(dto);
        return Ok(produto);
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        return Ok(await _service.ListarAsync());
    }
}
