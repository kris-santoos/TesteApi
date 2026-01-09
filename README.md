### OBJETIVOS ###

1º Criar lógica para salvar uma compra
2º Listar todas as compras
3º Listar última compra.
4º Melhorar performance da listagem de produtos e usuários.
5º Ajustar migration em caso de alteração dos objetos.
6º Adicionar no readme, a explicação das decisões tomadas para a solução desenvolvida.

## EXPLICAÇÃO:

Já tendo no projeto a entidade Compra, o DbSet<Compra> no contexto do banco de dados e o CriarCompraDto.

- O próximo passo foi ir para a camada de regra de negócio /Services:

Método CriarAsync:
Em primeiro momento, implementei o código com try catch para tratamento de erros, criei um objeto Compra usando os dados do dto, adicionando e salvando no banco gerando o Id da compra,
após salvar busco a mesma compra incluindo os dados do Usuário e do Produto. Se acontecer um erro em alguma etapa é lançado uma exceção com uma mensagem dizendo que a compra não pode ser realizada.

Método ListarAsynic:
Busca no banco todas as compras cadastradas e retorna a lista completa, se houver algum erro, lança uma exceção.

Método ListarUltimaAsync:
Busca no banco a última compra cadastrada, ordenando pela data e pegando a última ocorrência, se houver algum erro, lança uma exceção.

Já na Interface ICompraService: adicionei o método ListarUltimaAsync para conseguir buscar a última compra.

Adicionei o [JsonIgnore] nos Dtos de lista de compra, para eliminar o erro de loop infinito no Json Compra > Usuário > Compra..., visto que as tabelas estavam se chamando uma dentro da outra. Assim, a Api não trava.

Na /Controllers: Criei as rotas para criar, listar todas as compras e a última compra.

- No segundo commit:

Inclui o ModelState para conferir se usuário mandou os dados corretos, se estiver inválido a Api retorna BadRequest, avisando do erro nos dados. Utilizei também StatusCode para retornar uma resposta, caso aconteça algum erro no sistema. Ambos tendo em vista que antes só estava retornando código 200 de sucesso.

Criei o Dto de ErroResponse para padronizar melhor as respostas quando algo da errado ao invés da mensagem gigante de excessão.

No /Services novamente. Criei a validação para saber se o usuário ou o produto existem, para evitar que uma compra seja criada para um usuário que não existe, se não for encontrado, o sistema não deixa continuar e o mesmo é feito para o produto. E no UsuarioService o mesmo para o email.

Em ListarUltimaAsync ordenei do maior para o menor, pegando a primeira data, para evitar carregar todos os registros.

Inclui AsNoTracking (ele é como (nolock) do SQL) para não rastrear as entidades envolvidas para ganho em performance, isso faz com que não trave as entidades enquanto estiver buscando informações, lê sem rastrear. Incluído em todos os métodos de listas.

Troquei o var pela tipagem, para deixar mais claro.

##