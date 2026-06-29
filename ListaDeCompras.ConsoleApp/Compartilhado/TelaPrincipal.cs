

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
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
            return null;
        if (opcaoMenuPrincipal == "2")
            return null;
        if (opcaoMenuPrincipal == "3")
            return null;
        if (opcaoMenuPrincipal == "4")
            return null;

        return null;
    }
}
