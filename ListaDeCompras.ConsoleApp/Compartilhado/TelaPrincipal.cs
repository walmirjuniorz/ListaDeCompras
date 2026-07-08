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
        Categoria categoriaTeste = new Categoria("Produtos de Limpeza", CorCategoria.Vermelho);
        repositorioCategoria = new RepositorioCategoria();
        repositorioCategoria.Cadastrar(categoriaTeste);

        Produto produtoTeste = new Produto("Detergente Limpol", categoriaTeste, 1, UnidadeMedidaProduto.L, 18.50m);
        repositorioProduto = new RepositorioProduto();
        repositorioProduto.Cadastrar(produtoTeste);

        ListaCompras listaTeste = new ListaCompras("Compras do Mes");

        listaTeste.AdicionarItem(new ItemListaCompras(produtoTeste, 3));
        repositorioListaCompras = new RepositorioListaCompras();
        repositorioListaCompras.Cadastrar(listaTeste);
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
