using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Compartilhado.Arquivos;

namespace ListaDeCompras.ConsoleApp.Modulo.ModuloProduto;

public class RepositorioProduto : RepositorioBase<Produto>
{
    public RepositorioProduto(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Produto> ObterRegistro()
    {
        return contexto.Produtos;
    }
}
