using ListaDeCompras.ConsoleApp.Compartilhado.Arquivos;
using ListaDeCompras.ConsoleApp.Modulo.ModuloCategoria;
using ListaDeCompras.ConsoleApp.Modulo.ModuloListaCompras;
using ListaDeCompras.ConsoleApp.Modulo.ModuloProduto;
using ListaDeCompras.ConsoleApp.Modulos.ModuloListaCompras;
using static ListaDeCompras.ConsoleApp.Modulo.ModuloItemListaCompras.GeradorIdsItemListaCompras;

namespace ListaDeCompras.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    private readonly RepositorioCategoria repositorioCategoria;
    private readonly RepositorioProduto repositorioProduto;
    private readonly RepositorioListaCompras repositorioListaCompras;
    public TelaPrincipal()
    {
        ContextoJson contexto = new ContextoJson();

        contexto.Carregar();

        repositorioCategoria = new RepositorioCategoria(contexto);
        repositorioProduto = new RepositorioProduto(contexto);
        repositorioListaCompras = new RepositorioListaCompras(contexto);

    }

    public ITelaOpcoes? ObterOpcaoMenuPrincipal()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Lista De Compras");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gerenciar Categorias");
        Console.WriteLine("2 - Gerenciar Produtos");
        Console.WriteLine("3 - Gerenciar Listas de Compras");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");

        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
            return new TelaCategoria(repositorioCategoria, repositorioProduto);
        if (opcaoMenuPrincipal == "2")
            return new TelaProduto(repositorioProduto, repositorioCategoria);
        if (opcaoMenuPrincipal == "3")
            return new TelaListaCompras(repositorioListaCompras, repositorioProduto);
        if (opcaoMenuPrincipal == "4")
            return null;

        return null;
    }
}
