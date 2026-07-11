using System.Text.Json;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Compartilhado.Arquivos;
using ListaDeCompras.ConsoleApp.Modulo.ModuloCategoria;
using ListaDeCompras.ConsoleApp.Modulo.ModuloProduto;
using ListaDeCompras.ConsoleApp.Modulos.ModuloListaCompras;

ContextoJson contexto = new ContextoJson();

try
{
    contexto.Carregar();
}
catch (JsonException)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("O formato do arquivo de armazenamento está comrrompido!");
    Console.WriteLine("Proseguir com alteraçoes pode causar a sobrescrita de dados!");
    Console.ResetColor();
    Console.ReadLine();
}
catch
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Ocorreu um erro inesperado! O programa irá encerrar em 3 segundos...");
    Console.ResetColor();

    Thread.Sleep(TimeSpan.FromSeconds(3));

    return;
}

TelaPrincipal telaPrincipal = new TelaPrincipal(contexto);

while (true)
{
    ITelaOpcoes telaSelecionada = telaPrincipal.ObterOpcaoMenuPrincipal();

    if (telaSelecionada == null)
    {
        break;
    }

    while (true)
    {
        string? opcaoMenuInterno = telaSelecionada.ObterOpcaoMenu();

        if (opcaoMenuInterno == "S")
            break;

        if (telaSelecionada is ITelaCrud telaBase)
        {
            if (opcaoMenuInterno == "1")
                telaBase.Cadastrar();

            else if (opcaoMenuInterno == "2")
                telaBase.Editar();

            else if (opcaoMenuInterno == "3")
                telaBase.Excluir();

            else if (opcaoMenuInterno == "4")
                telaBase.VisualizarTodos(true);
            if (telaBase is TelaListaCompras telaListaCompras)
            {
                if (opcaoMenuInterno == "5")
                    telaListaCompras.AdiconarItem();

                else if (opcaoMenuInterno == "6")
                    telaListaCompras.RemoverItem();

                else if (opcaoMenuInterno == "7")
                    telaListaCompras.VisualizarItens(true);
            }
        }
    }
}
