using ClubeDaLeitura.ConsoleApp.Compartilhado;

TelaPrincipal telaPrincipal = new TelaPrincipal();

while (true)
{
    // Menu Principal da Aplicação
    //Polimorfismo
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

        if (telaSelecionada is TelaBase telaBase) // Caixa, Amigos, Revistas
        {
            if (opcaoMenuInterno == "1")
                telaBase.Cadastrar();

            else if (opcaoMenuInterno == "2")
                telaBase.Editar();

            else if (opcaoMenuInterno == "3")
                telaBase.Excluir();

            else if (opcaoMenuInterno == "4")
                telaBase.VisualizarTodos(true);
        }
    }
}
