using ApiTeste.Data;
using ApiTeste.Domain;
using ApiTeste.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ProdutoService : IProdutoService
{
    private readonly AppDbContext _context;

    public ProdutoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Produto> CriarAsync(CriarProdutoDto dto)
    {
        Produto produto = new Produto
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao
        };

        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();

        return produto;
    }

    public async Task<List<Produto>> ListarAsync()
    {
        return await _context.Produtos
            .AsNoTracking()
            .OrderBy(p => p.Id)
            .ToListAsync();
    }
}
