using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Compartilhado.Arquivos;
using ListaDeCompras.ConsoleApp.Modulos.ModuloListaCompras;

namespace ListaDeCompras.ConsoleApp.Modulo.ModuloListaCompras;

public class RepositorioListaCompras : RepositorioBase<ListaCompras>
{
    public RepositorioListaCompras(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<ListaCompras> ObterRegistro()
    {
        return contexto.ListaDeCompras;
    }
}
