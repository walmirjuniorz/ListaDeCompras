using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Compartilhado.Arquivos;

namespace ListaDeCompras.ConsoleApp.Modulo.ModuloCategoria;

public class RepositorioCategoria : RepositorioBase<Categoria>
{
    public RepositorioCategoria(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Categoria> ObterRegistro()
    {
        return contexto.Categorias;
    }
}
