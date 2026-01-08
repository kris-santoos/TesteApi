using ApiTeste.Domain;

namespace ApiTeste.Services.Interfaces
{
    public interface ICompraService
    {
        Task<Compra> CriarAsync(CriarCompraDto dto);
        Task<List<Compra>> ListarAsync();
    }
}
