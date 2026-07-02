using System;
using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.Modulo.ModuloProduto;

public class TelaProduto : TelaBase, ITelaOpcoes
{
    public TelaProduto(string nomeEntidade, RepositorioBase repositorio) : base(nomeEntidade, repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        throw new NotImplementedException();
    }

    protected override EntidadeBase ObterDadosCadastrais()
    {
        throw new NotImplementedException();
    }
}
