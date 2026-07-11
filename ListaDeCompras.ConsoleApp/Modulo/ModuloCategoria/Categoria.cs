using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.Modulo.ModuloCategoria;
/*
    - Campos obrigatórios:
            - Nome (texto único, máximo 50 caracteres)
            - Cor (seleção de paleta ou hexadecimal)
        - Não pode haver categorias com nomes duplicados
        - Não permitir excluir uma categoria caso tenha produtos vinculados
*/
public enum CorCategoria
{
    Branco,
    Vermelho,
    Verde,
    Azul
}
public static class GeradorIdsCategoria
{
    private static int contadorIds = 1;

    public static int GerarId()
    {
        return contadorIds++;
    }
}

public class Categoria : EntidadeBase
{
    public string Nome { get; set; }
    public CorCategoria Cor { get; set; }
    public Categoria()
    {
    }
    public Categoria(string nome, CorCategoria cor)
    {
        Id = GeradorIdsCategoria.GerarId();

        Nome = nome;
        Cor = cor;
    }
    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo \"Nome\" precisa ser preenchido!");

        else if (Nome.Length > 50)
            erros.Add("O campo \"Nome\" pode conter no máximo 50 caracteres");

        else if (Enum.IsDefined(Cor))
            erros.Add("O campo \"Nome\" deve conter uma seleçao permitida (Branco, Vermelho, Verde, Azul)");

        return erros;
    }
    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Categoria categoriaAtualizada = (Categoria)entidadeAtualizada;

        Nome = categoriaAtualizada.Nome;
        Cor = categoriaAtualizada.Cor;
    }
}

