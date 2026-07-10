using ListaDeCompras.ConsoleApp.Compartilhado.Arquivos;

namespace ListaDeCompras.ConsoleApp.Compartilhado;

public abstract class RepositorioBase<TEntidade> where TEntidade : EntidadeBase
{
    protected readonly ContextoJson contexto;
    protected readonly List<TEntidade> registros;

    protected RepositorioBase(ContextoJson contexto)
    {
        this.contexto = contexto;
        registros = ObterRegistro();
    }
    protected abstract List<TEntidade> ObterRegistro();

    public void Cadastrar(TEntidade novaRegistro)
    {
        registros.Add(novaRegistro);

        contexto.Salvar();
    }
    public bool Editar(int idSelecionado, TEntidade entidadeAtualizada)
    {
        TEntidade? entidadeSelecionada = SelecionarPorId(idSelecionado);

        if (entidadeSelecionada == null)
            return false;

        entidadeSelecionada.Atualizar(entidadeAtualizada);

        contexto.Salvar();

        return true;
    }
    public bool Excluir(int idSelecionado)
    {
        TEntidade? registroSelecionado = SelecionarPorId(idSelecionado);

        if (registroSelecionado == null)
            return false;

        bool conseguiuRemover = registros.Remove(registroSelecionado);

        if (!conseguiuRemover)
            return false;

        contexto.Salvar();

        return true;
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
