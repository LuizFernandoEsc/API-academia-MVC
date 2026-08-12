using Academia.Models;

namespace Academia.Repositório
{
    public interface InterfaceUsuarioRepositório
    {
        UsuarioModel listarPorId(int Id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);

        UsuarioModel Atualizar(UsuarioModel usuario);

        bool Excluir(int Id);
    }
}
