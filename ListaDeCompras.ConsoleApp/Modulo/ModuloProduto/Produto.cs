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
