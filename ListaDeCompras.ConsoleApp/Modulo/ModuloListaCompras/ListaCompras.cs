using ListaDeCompras.ConsoleApp.Compartilhado;
using static ListaDeCompras.ConsoleApp.Modulo.ModuloItemListaCompras.GeradorIdsItemListaCompras;

namespace ListaDeCompras.ConsoleApp.Modulo.ModuloCompra;
/*
    - Campos obrigatórios:
            - Nome da lista (mínimo 3 caracteres, máximo 100)
            - Data de criação (automática)
        - Status possíveis: Aberta / Concluída
*/
public enum StatusListaCompras
{
    Aberta,
    Concluida
}
public static class GeradorIdsListaCompras
{
    private static int contadorIds = 1;

    public static int GerarId()
    {
        return contadorIds++;
    }
    public class ListaCompras : EntidadeBase
    {
        public string Nome { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public StatusListaCompras Status { get; private set; } = StatusListaCompras.Aberta;
        public ItemListaCompras[] Itens { get; set; } = new ItemListaCompras[100];
        public ListaCompras(string nome)
        {
            Id = GeradorIdsListaCompras.GerarId();
            Nome = nome;
            DataCriacao = DateTime.Now;
        }
        public void AdicionarItem(ItemListaCompras itemLista)
        {
            for (int i = 0; i < Itens.Length; i++)
            {
                if (Itens[i] == null)
                {
                    Itens[i] = itemLista;
                    return;
                }
            }
        }
        public void RemoverItem(int idItemListaCompras)
        {
            for (int i = 0; i < Itens.Length; i++)
            {
                if (Itens[i] == null)
                    continue;
                if (Itens[i].Id == idItemListaCompras)
                {
                    Itens[i] = null;
                    return;
                }
            }
        }
        public override void Atualizar(EntidadeBase entidadeAtualizada)
        {
            ListaCompras listaAtualizada = (ListaCompras)entidadeAtualizada;

            Nome = listaAtualizada.Nome;
            Status = listaAtualizada.Status;
        }
    }
}
