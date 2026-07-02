using ClubeDaLeitura.ConsoleApp.Compartilhado;
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
public class GeradorIdsProduto
{
    private static int contadorIds = 1;

    public static int GerarId()
    {
        return contadorIds++;
    }
}
public class Produto : EntidadeBase
{
    public string Nome { get; private set; }
    public Categoria Categoria { get; private set; }
    public int Preco { get; private set; }
    public UnidadeMedidaProduto UnidadeProduto { get; private set; }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Produto produtoAtualizado = (Produto)entidadeAtualizada;

        Nome = produtoAtualizado.Nome;
        Preco = produtoAtualizado.Preco;
    }
}
