using ListaDeCompras.ConsoleApp.Modulo.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    private readonly RepositorioCategoria repositorioCategoria;
    public TelaPrincipal()
    {
        Categoria categoriaTeste = new Categoria("Produtos de Limpeza", CorCategoria.Vermelho);

        repositorioCategoria = new RepositorioCategoria();
        repositorioCategoria.Cadastrar(categoriaTeste);
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
            return new TelaCategoria(repositorioCategoria);
        if (opcaoMenuPrincipal == "2")
            return null;
        if (opcaoMenuPrincipal == "3")
            return null;
        if (opcaoMenuPrincipal == "4")
            return null;

        return null;
    }
}
