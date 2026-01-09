using ApiTeste.Domain;
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
        if (!ModelState.IsValid)
        {
            return BadRequest(new ErrorResponse(
                "Dados inválidos",
                string.Join("; ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))
            ));
        }

        try
        {
            Produto produto = await _service.CriarAsync(dto);
            return StatusCode(201, produto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ErrorResponse(
                "Erro ao criar produto",
                ex.Message
            ));
        }
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        try
        {
            List<Produto> produtos = await _service.ListarAsync();
            return Ok(produtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ErrorResponse(
                "Erro ao listar produtos",
                ex.Message
            ));
        }
    }
}
