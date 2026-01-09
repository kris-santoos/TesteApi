using ApiTeste.Data;
using ApiTeste.Domain;
using ApiTeste.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public class CompraService : ICompraService
{
    private readonly AppDbContext _context;

    public CompraService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Compra> CriarAsync(CriarCompraDto dto)
    {
        var usuarioExiste = await _context.Usuarios
            .AnyAsync(u => u.Id == dto.UsuarioId);

        if (!usuarioExiste)
        {
            throw new InvalidOperationException("Usuário não encontrado");
        }

        var produtoExiste = await _context.Produtos
            .AnyAsync(p => p.Id == dto.ProdutoId);

        if (!produtoExiste)
        {
            throw new InvalidOperationException("Produto não encontrado");
        }

        var compra = new Compra
        {
            UsuarioId = dto.UsuarioId,
            ProdutoId = dto.ProdutoId,

        };

        _context.Compras.Add(compra);

        await _context.SaveChangesAsync();

        return await _context.Compras
            .Include(c => c.Usuario)
            .Include(c => c.Produto)
            .FirstOrDefaultAsync(c => c.Id == compra.Id);     
    }

    public async Task<List<Compra>> ListarAsync()
    {
        try { 
            return await _context.Compras
                .Include(c => c.Usuario)
                .Include(c => c.Produto)      
                .ToListAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Não foi possível listar as compras. Mensagem: {ex.Message}");
        }

    }

    public async Task<Compra> ListarUltimaAsync()
    {
        try { 
            return await _context.Compras
                .Include(c => c.Usuario)
                .Include(c => c.Produto)
                .AsNoTracking()
                .OrderByDescending(c => c.DataCadastro)
                .FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Não foi possível listar a última compra. Mensagem: {ex.Message}");
        }

    }
}
