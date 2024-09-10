using API.Data.DTO.Usuario;
using API.Domain.Models;

namespace API.Interfaces.DAO
{
    public interface IUsuarioDAO
    {
        IEnumerable<Usuario> BuscarUsuario();

        Usuario BuscarUsuario(int idUsuario);

        Usuario BuscarUsuario(string emailUsuario);

        int CriarUsuario(CreateUsuarioDTO usuarioRecebido);

        void AtualizarUsuario(UpdateUsuarioDTO usuarioRecebido);

        void RemoverUsuario(int idUsuario);
    }
}
