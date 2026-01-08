using System.ComponentModel.DataAnnotations;

public class CriarProdutoDto
{
    [Required]
    public string Nome { get; set; }

    public string Descricao { get; set; }
}
