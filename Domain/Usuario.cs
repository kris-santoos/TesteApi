using System.Text.Json.Serialization;

namespace ApiTeste.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public ICollection<Compra> Compras { get; set; }
    }
}
