using Academia.Controllers;
using Academia.Data;
using Academia.Models;

namespace Academia.Repositório
{
    public class UsuarioRepositório : InterfaceUsuarioRepositório
    {
        private readonly BancoContext _bancoContext;


        public UsuarioModel listarPorId(int Id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == Id);
        }



        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }



        public UsuarioRepositório(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;

        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = listarPorId(usuario.Id);
            if (usuarioDb == null)
            {
                throw new Exception("Houve um erro na atualização do usuário");
            }
            else
            {
                usuarioDb.name = usuario.name;
                usuarioDb.numero = usuario.numero;
                usuarioDb.cpf = usuario.cpf;
                usuarioDb.plano = usuario.plano;
                _bancoContext.Usuarios.Update(usuarioDb);
                _bancoContext.SaveChanges();
                return usuarioDb;
            }
        }
        public bool Excluir(int Id)
        {
            UsuarioModel usuarioDb = listarPorId(Id);
            if (usuarioDb == null)
            {
                throw new Exception("Houve um erro na exclusão do usuário");
            }
            else
            {
                _bancoContext.Usuarios.Remove(usuarioDb);
                _bancoContext.SaveChanges();
                return true;
            }
        }
    }
}
