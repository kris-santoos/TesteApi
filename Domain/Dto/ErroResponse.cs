public class ErrorResponse
{
    public string Mensagem { get; set; }
    public string? Detalhes { get; set; }

    public ErrorResponse(string mensagem, string? detalhes = null)
    {
        Mensagem = mensagem;
        Detalhes = detalhes;
    }
}