namespace ApiTeste.Domain
{
    public class Compra
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    }
}
