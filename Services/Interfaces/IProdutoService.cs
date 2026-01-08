using ApiTeste.Domain;

namespace ApiTeste.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<Produto> CriarAsync(CriarProdutoDto dto);
        Task<List<Produto>> ListarAsync();
    }
}
