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
        try { 
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
        catch (Exception ex)
        {

            throw new Exception($"Não foi possível realizar a compra. Mensagem: {ex.Message}");
        }
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
                .OrderBy(c => c.DataCadastro)
                .LastOrDefaultAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Não foi possível listar a última compra. Mensagem: {ex.Message}");
        }

    }
}
