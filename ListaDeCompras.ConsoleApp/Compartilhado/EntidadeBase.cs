using System.Security.Cryptography;
namespace ListaDeCompras.ConsoleApp.Compartilhado;

public abstract class EntidadeBase
{
    public int Id { get; set; }

    public abstract void Atualizar(EntidadeBase entidadeAtualizada);

    internal bool Remove<TEntidade>(TEntidade registros) where TEntidade : EntidadeBase
    {
        throw new NotImplementedException();
    }
}
