using API.Data.DTO.Autenticacao;
using API.Domain.Exceptions;
using API.Domain.Models;
using API.Interfaces.DAO;
using API.Interfaces.Services;
using Base;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IUsuarioDAO _usuarioContext;

        public AutenticacaoService(IUsuarioDAO usuarioContext)
        {
            _usuarioContext = usuarioContext;
        }

        public string GerarToken(LoginAutenticacaoDTO loginRecebido)
        {
            ReadAutenticacaoDTO usuarioValidado = ValidaUsuarioRecebido(loginRecebido.Email, loginRecebido.Senha);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AuthBase.SecretKey);

            var tokenDescricao = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                                                    new Claim(ClaimTypes.Email, usuarioValidado.Email),
                                                    new Claim(ClaimTypes.Role, usuarioValidado.TipoUsuario.ToString())
                                                }),

                Expires = DateTime.UtcNow.AddMinutes(30),  // Token expira em 30 minutos
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescricao);
            return tokenHandler.WriteToken(token);
        }

        private ReadAutenticacaoDTO ValidaUsuarioRecebido(string email, string senha)
        {
            try
            {
                ReadAutenticacaoDTO usuarioAutenticado = new ReadAutenticacaoDTO() { Email = email, Senha = senha };
                Usuario usuarioRecuperado = _usuarioContext.BuscarUsuario(email);

                if (ValidaLoginUsuario(usuarioAutenticado, usuarioRecuperado))
                {
                    usuarioAutenticado = mapearUsuarioValidado(usuarioAutenticado, usuarioRecuperado);
                }
                else
                {
                    throw new AutenticacaoException("Email ou senha incorreto");
                }

                return usuarioAutenticado;
            }
            catch (UsuarioNaoEncontradoException usuarioEx)
            {
                throw new UsuarioNaoEncontradoException(usuarioEx.Message);
            }
            catch (AutenticacaoException autenticacaoEx)
            {
                throw new AutenticacaoException(autenticacaoEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool ValidaLoginUsuario(ReadAutenticacaoDTO usuarioAutenticar, Usuario usuarioRecebidoBanco)
        {
            if (usuarioAutenticar.Email.ToUpper() != usuarioRecebidoBanco.Email.ToUpper())
            {
                return false;
            }
            if (usuarioAutenticar.Senha != usuarioRecebidoBanco.Senha)
            {
                return false;
            }

            return true;
        }

        private ReadAutenticacaoDTO mapearUsuarioValidado(ReadAutenticacaoDTO usuarioAutenticado, Usuario usuarioRecuperadoBanco)
        {
            usuarioAutenticado.Ativo = usuarioRecuperadoBanco.Ativo;
            usuarioAutenticado.TipoUsuario = usuarioRecuperadoBanco.TipoUsuario;
            return usuarioAutenticado;
        }
    }
}
