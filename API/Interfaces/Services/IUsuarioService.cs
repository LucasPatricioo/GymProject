using API.Data.DTO.Usuario;
using API.Domain.Models;

namespace API.Interfaces.Services
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> BuscarUsuario();
        Usuario BuscarUsuario(int idUsuario);
        Usuario CriarUsuario(CreateUsuarioDTO usuarioRecebido);
        Usuario AtualizarUsuario(UpdateUsuarioDTO usuarioRecebido);
        void RemoverUsuario(int idUsuario);
    }
}
