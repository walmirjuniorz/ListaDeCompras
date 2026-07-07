using ListaDeCompras.ConsoleApp.Modulo.ModuloProduto;

namespace ListaDeCompras.ConsoleApp.Modulo.ModuloItemListaCompras;
/*
    Regras de Negócio:
            - Campos obrigatórios:
            - Produto (seleção obrigatória)
            - Quantidade (número positivo)
        - Não pode adicionar o mesmo produto duas vezes na mesma lista
        - O valor total da lista deve ser calculado automaticamente (soma dos preços estimados × quantidades)
*/
public static class GeradorIdsItemListaCompras
{
    private static int contadorIds = 1;

    public static int GerarId()
    {
        return contadorIds++;
    }
    public class ItemListaCompras
    {
        public int Id { get; private set; }
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoTotal
        {
            get
            {
                return Produto.Preco * Quantidade;
            }
        }
        public ItemListaCompras(Produto produto, int qauntidade)
        {
            Id = GeradorIdsItemListaCompras.GerarId();
            Produto = produto;
            Quantidade = qauntidade;
        }
    }
}

