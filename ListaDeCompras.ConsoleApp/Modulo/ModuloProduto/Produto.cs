using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Modulo.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.Modulo.ModuloProduto;
/*
    Campos obrigatórios:
            - Nome (2 a 100 caracteres)
            - Categoria (seleção obrigatória)
            - Unidade de medida (ex: kg, unidade, litro, caixa)
        - Preço aproximado
        - Não pode haver produtos com o mesmo nome na mesma categoria
*/
public enum UnidadeMedidaProduto
{
    Unidade,
    Caixa,
    Duzia,
    Kg,
    L,
    Ml,
    G
}
public static class GeradorIdsProduto
{
    private static int contadorIds = 1;

    public static int GerarId()
    {
        return contadorIds++;
    }
}
public class Produto : EntidadeBase
{
    public string Nome { get; set; }
    public Categoria Categoria { get; set; }
    public int ValorUnidadeMedida { get; set; }
    public UnidadeMedidaProduto UnidadeMedida { get; set; } = UnidadeMedidaProduto.Unidade;
    public decimal Preco { get; set; }

    public Produto()
    {
    }
    public Produto(string nome, Categoria categoria, int valorUnidadeMedida, UnidadeMedidaProduto unidadeProduto, decimal preco)
    {
        Id = GeradorIdsCategoria.GerarId();

        Nome = nome;
        Categoria = categoria;
        ValorUnidadeMedida = valorUnidadeMedida;
        UnidadeMedida = unidadeProduto;
        Preco = preco;
    }
    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo \"Nome\" precisa ser preenchido!");

        else if (Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" precisa ter entre 2 e 100 caracteres!");

        if (Categoria == null)
            erros.Add("O campo \"Categoria\" deve ser preenchido!");

        if (ValorUnidadeMedida == 0)
            erros.Add("O campo \"Valor de Medida\" nao pode conter o valor zero!");

        if (!Enum.IsDefined(UnidadeMedida))
            erros.Add("O campo \"Unidade de Medida\" deve conter uma seleçao permitida (Unidade, Caixa, Duzia, Kg, L, Ml, G)");

        if (Preco == 0)
            erros.Add("O campo \"Valor de Medida\" nao pode conter o valor zero!");

        return erros;
    }
    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Produto produtoAtualizado = (Produto)entidadeAtualizada;

        Nome = produtoAtualizado.Nome;
        Categoria = produtoAtualizado.Categoria;
        ValorUnidadeMedida = produtoAtualizado.ValorUnidadeMedida;
        UnidadeMedida = produtoAtualizado.UnidadeMedida;
        Preco = produtoAtualizado.Preco;
    }
}
