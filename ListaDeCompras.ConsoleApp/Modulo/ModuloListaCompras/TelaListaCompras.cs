using System.ComponentModel;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Modulo.ModuloProduto;
using static ListaDeCompras.ConsoleApp.Modulo.ModuloCompra.GeradorIdsListaCompras;
using static ListaDeCompras.ConsoleApp.Modulo.ModuloItemListaCompras.GeradorIdsItemListaCompras;

namespace ListaDeCompras.ConsoleApp.Modulo.ModuloListaCompras;

public class TelaListaCompras : TelaBase, ITelaOpcoes
{
    private readonly RepositorioListaCompras repositorioListaCompras;
    private readonly RepositorioProduto repositorioProduto;

    public TelaListaCompras(
        RepositorioListaCompras repositorioListaCompras,
        RepositorioProduto repositorioProduto) : base("ListaCompras", repositorioListaCompras)
    {
        this.repositorioListaCompras = repositorioListaCompras;
        this.repositorioProduto = repositorioProduto;
    }
    public override string? ObterOpcaoMenu()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Lista de Compras");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar Lista de Compra");
        Console.WriteLine("2 - Editar Lista de Compra");
        Console.WriteLine("3 - Excluir Lista de Compra");
        Console.WriteLine("4 - Visualizar Listas de Compras");
        Console.WriteLine("5 - Adicionar item á Listas de Compras");
        Console.WriteLine("6 - Remover item de Listas de Compras");
        Console.WriteLine("7 - Visualizar itens de Listas de Compras");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");

        string? opcaoMenuInterno = Console.ReadLine()?.ToUpper();

        return opcaoMenuInterno;
    }
    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Categorias");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -15} | {3, -10}",
            "Id", "Nome", "Data de Criaçao", "Status"
        );

        EntidadeBase[] registros = repositorioListaCompras.SelecionarTodos();

        for (int i = 0; i < registros.Length; i++)
        {
            ListaCompras l = (ListaCompras)registros[i];

            if (l == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -15} | {3, -10}",
                l.Id, l.Nome, l.DataCriacao.ToShortDateString(), l.Status
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
        }
    }
    public void AdiconarItem()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Adiçao de item a lista de compras");
        Console.WriteLine("---------------------------------");

        VisualizarTodos(false);

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite o Id da lista que deseja editar: ");
        int idListaSelecionada = Convert.ToInt32(Console.ReadLine());

        ListaCompras? listaSelecionada = (ListaCompras?)repositorioListaCompras.SelecionarPorId(idListaSelecionada);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Gestao da lista de compras \"{listaSelecionada.Nome}\"");
        Console.WriteLine("---------------------------------");

        VisualizarProdutos();

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite o Id do produto que deseja adiconar: ");
        int idProdutoSelecionado = Convert.ToInt32(Console.ReadLine());

        Produto? produtoSelecionado = (Produto?)repositorioProduto.SelecionarPorId(idProdutoSelecionado);

        Console.WriteLine("Digite a quantidade do produto: ");
        int quantidadeProduto = Convert.ToInt32(Console.ReadLine());

        ItemListaCompras itemListaCompras = new ItemListaCompras(produtoSelecionado!, quantidadeProduto);

        Console.Write($"Deseja realmente adicionar {produtoSelecionado.Nome} x{quantidadeProduto} a lista? (s/N): ");
        string opcaoSelecionada = Console.ReadLine();

        if (opcaoSelecionada.ToUpper() != "S")
            return;

        listaSelecionada.AdicionarItem(itemListaCompras);

        repositorioListaCompras.Editar(idListaSelecionada, listaSelecionada);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O item \"{produtoSelecionado!.Nome} x{quantidadeProduto}\" foi cadastrado com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
    }
    public void RemoverItem()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Remoçao de Itens de Lista de Compras ");
        Console.WriteLine("---------------------------------");

        ListaCompras listaSelecionada = VisualizarItens(false);

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite o Id do item da lista que deseja remover: ");
        int idItemListaSelecionada = Convert.ToInt32(Console.ReadLine());

        listaSelecionada.RemoverItem(idItemListaSelecionada);

        repositorioListaCompras.Editar(listaSelecionada.Id, listaSelecionada);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O item foi removido com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
    }
    public ListaCompras VisualizarItens(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualizaçao de Itens de Lista de Compras ");
            Console.WriteLine("---------------------------------");
        }

        VisualizarTodos(false);

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite o Id da lista que deseja visualizar: ");
        int idListaSelecionada = Convert.ToInt32(Console.ReadLine());

        ListaCompras? listaSelecionada = (ListaCompras?)repositorioListaCompras.SelecionarPorId(idListaSelecionada);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Gestao da lista de compras \"{listaSelecionada.Nome}\"");
        Console.WriteLine("---------------------------------");
        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -15} | {3, -10}",
            "Id", "Produto", "Quantidade", "Preco Total"
        );

        ItemListaCompras[] itensLista = listaSelecionada.Itens;

        for (int i = 0; i < itensLista.Length; i++)
        {
            ItemListaCompras item = itensLista[i];

            if (item == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -15} | {3, -10}",
                item.Id, item.Produto.Nome, item.Quantidade, item.PrecoTotal.ToString("C2")
            );
        }
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
        }
        return listaSelecionada;
    }
    protected override EntidadeBase ObterDadosCadastrais()
    {
        Console.Write("Digite o nome da lista de compras: ");
        string? nome = Console.ReadLine();

        return new ListaCompras(nome!);
    }
    private void VisualizarProdutos()
    {
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
                p.Id,
                p.Nome,
                p.Categoria.Nome,
                string.Join(" ", p.ValorUnidadeMedida, p.UnidadeMedida),
                p.Preco.ToString("C2")
                );
        }
    }
}
