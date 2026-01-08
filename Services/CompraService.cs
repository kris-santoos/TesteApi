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
        return null;
    }

    public async Task<List<Compra>> ListarAsync()
    {
        return null;
    }
}
