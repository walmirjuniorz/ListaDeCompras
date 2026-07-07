namespace ListaDeCompras.ConsoleApp.Compartilhado;

public abstract class RepositorioBase<TEntidade> where TEntidade : EntidadeBase
{
    private TEntidade[] registros = new TEntidade[100];

    public void Cadastrar(TEntidade novaRegistro)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
            {
                registros[i] = novaRegistro;
                break;
            }
        }
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
        for (int i = 0; i < registros.Length; i++)
        {
            TEntidade obj = registros[i];

            if (obj == null)
                continue;

            if (obj.Id == idSelecionado)
            {
                registros[i] = null;
                return true;
            }
        }

        return false;
    }
    public TEntidade? SelecionarPorId(int idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            TEntidade obj = registros[i];

            if (obj == null)
                continue;

            if (obj.Id == idSelecionado)
                return obj;
        }

        return null;
    }
    public TEntidade[] SelecionarTodos()
    {
        return registros;
    }
}
