using System.Text.Json.Serialization;

namespace ApiTeste.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public ICollection<Compra> Compras { get; set; }
    }
}
