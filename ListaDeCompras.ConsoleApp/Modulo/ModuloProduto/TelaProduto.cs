using System;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Modulo.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.Modulo.ModuloProduto;

public class TelaProduto : TelaBase<Produto>, ITelaOpcoes, ITelaCrud
{
    private readonly RepositorioCategoria repositorioCategoria;
    private readonly RepositorioProduto repositorioProduto;

    public TelaProduto(
        RepositorioProduto repositorioProduto,
        RepositorioCategoria repositorioCategoria) : base("Produto", repositorioProduto)
    {
        this.repositorioProduto = repositorioProduto;
        this.repositorioCategoria = repositorioCategoria;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualizacao de Produto");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -20} | {3, -11} | {4, -6}",
            "Id", "Nome", "Categoria", "Unidade", "Preco Aproximado"
            );

        List<Produto> produtos = repositorioProduto.SelecionarTodos();

        foreach (Produto p in produtos)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -20} | {3, -11} | {4, -6}",
                p.Id,
                p.Nome,
                p.Categoria.Nome,
                string.Join(" ", p.ValorUnidadeMedida, p.UnidadeMedida),
                p.Preco.ToString("C2")
                );
        }
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
        }
    }
    protected override Produto ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do produto: ");
        string? nome = Console.ReadLine();

        Console.WriteLine("---------------------------------");

        VisualizarCategorias();

        Console.WriteLine("---------------------------------");

        Console.Write("Digite o Id da Categoria que deseja selecionar: ");
        int IdCategoria = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("---------------------------------");

        Categoria? categoriaSelecionada = repositorioCategoria.SelecionarPorId(IdCategoria);

        Console.Write("Digite o valor ou a quantidade da unidade de medida do produto: ");
        int valorUnidadeMedida = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Selecione a unidade de medida disponível");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Unidade (Padrao)");
        Console.WriteLine("2 - Caixa");
        Console.WriteLine("3 - Duzia");
        Console.WriteLine("4 - Kg");
        Console.WriteLine("5 - L");
        Console.WriteLine("6 - Ml");
        Console.WriteLine("7 - G");
        Console.WriteLine("---------------------------------");
        Console.Write("Informe a unidade de medida selecionada: ");
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
    protected override bool ExisteRegistroComInformacoesExclusivas(Produto entidade, int? idIgnorado = null)
    {
        List<Produto> produtos = repositorioProduto.SelecionarTodos();

        foreach (Produto p in produtos)
        {
            if (p.Id != idIgnorado &&
                p.Nome.ToLower() == entidade.Nome.ToLower() &&
                p.Categoria == entidade.Categoria
            )
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Já existe um produto com o nome {p.Nome} na categoria!");
                Console.WriteLine("---------------------------------");

                return true;
            }
        }
        return base.ExisteRegistroComInformacoesExclusivas(entidade, idIgnorado);
    }
    private void VisualizarCategorias()
    {
        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10}",
            "Id", "Nome", "Cor"
        );

        List<Categoria> categorias = repositorioCategoria.SelecionarTodos();

        foreach (Categoria c in categorias)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10}",
                c.Id, c.Nome, c.Cor
            );
        }
    }
}
