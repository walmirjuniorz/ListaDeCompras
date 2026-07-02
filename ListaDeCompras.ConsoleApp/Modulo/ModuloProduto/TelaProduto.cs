using System;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Modulo.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.Modulo.ModuloProduto;

public class TelaProduto : TelaBase, ITelaOpcoes
{
    private readonly RepositorioCategoria repositorioCategoria;
    private readonly RepositorioProduto repositorioProduto;

    public TelaProduto(
        RepositorioProduto repositorioProduto,
        RepositorioCategoria repositorioCategoria
        ) : base("Produto", repositorioProduto)
    {
        this.repositorioProduto = repositorioProduto;
        this.repositorioCategoria = repositorioCategoria;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualizacao de Produtos");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -20} | {3, -11} | {4, -6}",
            "Id", "Nome", "Categoria", "Unidade", "Preco Aproximado"
            );

        EntidadeBase[] produtos = repositorioProduto.SelecionarTodos();

        for (int i = 0; i < produtos.Length; i++)
        {
            Produto p = (Produto)produtos[i];

            if (p == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -20} | {3, -11} | {4, -6}",
                p.Id, p.Nome, p.Categoria.Nome, p.UnidadeMedida, p.Preco
                );
        }
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
        }
    }
    protected override EntidadeBase ObterDadosCadastrais()
    {
        Console.Write("Informe o nome do produto: ");
        string? nome = Console.ReadLine();

        Console.WriteLine("---------------------------------");

        VisualizarCategorias();

        Console.WriteLine("---------------------------------");

        Console.Write("Informe o Id da Categoria que deseja selecionar: ");
        int IdCategoria = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("---------------------------------");

        Categoria categoriaSelecionada = (Categoria)repositorioCategoria.SelecionarPorId(IdCategoria);

        Console.Write("Digite o valor ou a quantidade da unidade de medida do produto: ");
        int valorUnidadeMedida = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Selecione a unidade de medida");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Unidade (Padrao)");
        Console.WriteLine("2 - Caixa");
        Console.WriteLine("3 - Duzia");
        Console.WriteLine("4 - Kg");
        Console.WriteLine("5 - L");
        Console.WriteLine("6 - Ml");
        Console.WriteLine("7 - G");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Informe a unidade de medida selecionada: ");
        string unidadeSelecionada = Console.ReadLine();

        UnidadeMedidaProduto unidadeMedida;

        switch (unidadeSelecionada)
        {
            case "1":
                unidadeMedida = UnidadeMedidaProduto.Unidade;
                break;
            case "2":
                unidadeMedida = UnidadeMedidaProduto.Caixa;
                break;
            case "3":
                unidadeMedida = UnidadeMedidaProduto.Duzia;
                break;
            case "4":
                unidadeMedida = UnidadeMedidaProduto.Kg;
                break;
            case "5":
                unidadeMedida = UnidadeMedidaProduto.L;
                break;
            case "6":
                unidadeMedida = UnidadeMedidaProduto.Ml;
                break;
            case "7":
                unidadeMedida = UnidadeMedidaProduto.G;
                break;
            default:
                unidadeMedida = UnidadeMedidaProduto.Unidade;
                break;
        }

        Console.Write("Digite o preço aproximado: ");
        decimal precoAproximado = Convert.ToDecimal(Console.ReadLine());

        return new Produto(
            nome!,
            categoriaSelecionada!,
            valorUnidadeMedida,
            unidadeMedida,
            precoAproximado
            );
    }
    private void VisualizarCategorias()
    {
        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10}",
            "Id", "Nome", "Cor"
        );

        EntidadeBase[] registros = repositorioCategoria.SelecionarTodos();

        for (int i = 0; i < registros.Length; i++)
        {
            Categoria c = (Categoria)registros[i];

            if (c == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10}",
                c.Id, c.Nome, c.Cor
            );
        }
    }
}
