using ClubeDaLeitura.ConsoleApp.Compartilhado;

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
    public string Nome { get; private set; }
    public CorCategoria Cor { get; private set; }

    public Categoria(string nome, CorCategoria cor)
    {
        Id = GeradorIdsCategoria.GerarId();

        Nome = nome;
        Cor = cor;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Categoria categoriaAtualizada = (Categoria)entidadeAtualizada;

        Nome = categoriaAtualizada.Nome;
        Cor = categoriaAtualizada.Cor;
    }
}

