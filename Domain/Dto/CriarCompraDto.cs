using System.ComponentModel.DataAnnotations;

public class CriarCompraDto
{
    [Required]
    public int UsuarioId { get; set; }

    [Required]
    public int ProdutoId { get; set; }
}
