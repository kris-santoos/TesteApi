using System.ComponentModel.DataAnnotations;

public class CriarUsuarioDto
{
    [Required]
    public string Nome { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public string Telefone { get; set; }
}
