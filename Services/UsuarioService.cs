using ApiTeste.Data;
using ApiTeste.Domain;
using ApiTeste.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public class UsuarioService : IUsuarioService
{
    private readonly AppDbContext _context;

    public UsuarioService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario> CriarAsync(CriarUsuarioDto dto)
    {
        var usuario = new Usuario
        {
            Nome = dto.Nome,
            Email = dto.Email,
            Telefone = dto.Telefone
        };

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return usuario;
    }

    public async Task<List<Usuario>> ListarAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }
}
