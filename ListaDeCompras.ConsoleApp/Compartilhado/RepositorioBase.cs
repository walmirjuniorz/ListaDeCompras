namespace ListaDeCompras.ConsoleApp.Compartilhado;

public abstract class RepositorioBase<TEntidade> where TEntidade : EntidadeBase
{
    private List<TEntidade> registros = new List<TEntidade>();

    public void Cadastrar(TEntidade novaRegistro)
    {
        registros.Add(novaRegistro);
    }
    public bool Editar(int idSelecionado, TEntidade entidadeAtualizada)
    {
        TEntidade? entidadeSelecionada = SelecionarPorId(idSelecionado);

        if (entidadeSelecionada == null)
            return false;

        entidadeSelecionada.Atualizar(entidadeAtualizada);

        return true;
    }
    public bool Excluir(int idSelecionado)
    {
        TEntidade? registroSelecionado = SelecionarPorId(idSelecionado);

        if (registroSelecionado == null)
            return false;

        return registros.Remove(registroSelecionado);
    }
    public TEntidade? SelecionarPorId(int idSelecionado)
    {
        foreach (TEntidade obj in registros)
        {
            if (obj.Id == idSelecionado)
            {
                return obj;
            }
        }

        return null;

    }
    public List<TEntidade> SelecionarTodos()
    {
        return registros;
    }
}
