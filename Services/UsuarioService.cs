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
        var emailExiste = await _context.Usuarios
            .AnyAsync(u => u.Email.ToLower() == dto.Email.ToLower());

        if (emailExiste)
        {
            throw new InvalidOperationException("Falha ao criar usuário");
        }

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
        return await _context.Usuarios
            .AsNoTracking()
            .OrderBy(u => u.Id)
            .ToListAsync();
    }
}
