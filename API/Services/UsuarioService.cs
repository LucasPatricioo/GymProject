using API.Data.DTO.Usuario;
using API.Domain.Exceptions;
using API.Domain.Models;
using API.Interfaces.DAO;
using API.Interfaces.Services;

namespace API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioDAO _usuarioContext;

        public UsuarioService(IUsuarioDAO usuarioDAO)
        {
            _usuarioContext = usuarioDAO;
        }

        public IEnumerable<Usuario> BuscarUsuario()
        {
            try
            {
                var listaUsuariosRecebidos = _usuarioContext.BuscarUsuario();
                return listaUsuariosRecebidos;
            }
            catch (Exception ex)
            {
                throw new UsuarioException(ex.Message);
            }
        }

        public Usuario BuscarUsuario(int idUsuario)
        {
            try
            {
                Usuario usuarioRecebido = _usuarioContext.BuscarUsuario(idUsuario);
                return usuarioRecebido;
            }
            catch(UsuarioNaoEncontradoException usuarioException)
            {
                throw new UsuarioNaoEncontradoException(usuarioException.Message);
            }
            catch (Exception ex)
            {
                throw new UsuarioException(ex.Message);
            }
        }

        public Usuario CriarUsuario(CreateUsuarioDTO usuarioRecebido)
        {
            try
            {
                int idUsuarioRetornado = _usuarioContext.CriarUsuario(usuarioRecebido);
                Usuario usuarioRetornado = BuscarUsuario(idUsuarioRetornado);
                return usuarioRetornado;
            }
            catch (Exception ex)
            {
                throw new UsuarioException(ex.Message);
            }
        }

        public Usuario AtualizarUsuario(UpdateUsuarioDTO usuarioRecebido)
        {
            try
            {
                if (!UsuarioExiste(usuarioRecebido.IdUsuario))
                {
                    throw new UsuarioException("Usuário não existe");
                }
                _usuarioContext.AtualizarUsuario(usuarioRecebido);
                Usuario usuarioRetornado = BuscarUsuario(usuarioRecebido.IdUsuario);
                return usuarioRetornado;
            }
            catch (Exception ex)
            {
                throw new UsuarioException(ex.Message);
            }
        }

        public void RemoverUsuario(int idUsuario)
        {
            try
            {
                if (!UsuarioExiste(idUsuario))
                {
                    throw new UsuarioException("Usuário não existe");
                }
                _usuarioContext.RemoverUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                throw new UsuarioException(ex.Message);
            }
        }

        #region Validações

        private bool UsuarioExiste(int idUsuario)
        {
            return BuscarUsuario(idUsuario) is not null;
        }


        #endregion
    }
}
