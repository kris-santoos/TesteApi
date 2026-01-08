using ApiTeste.Domain;

namespace ApiTeste.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> CriarAsync(CriarUsuarioDto dto);
        Task<List<Usuario>> ListarAsync();
    }
}
