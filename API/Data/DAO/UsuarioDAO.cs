using API.Data.DTO.Usuario;
using API.Domain.Exceptions;
using API.Domain.Models;
using API.Interfaces.DAO;
using Base;
using Dapper;
using MySql.Data.MySqlClient;

namespace API.Data.DAO
{
    public class UsuarioDAO : IUsuarioDAO
    {
        private readonly string _connectionString = ContextBase.ConnectionString;

        public IEnumerable<Usuario> BuscarUsuario()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    con.Open();

                    string sql = "SELECT IdUsuario, NomeCompleto, DataNascimento, Email, Senha, DataCriado, Ativo, TipoUsuario FROM usuarios";

                    var listaUsuariosRecebidos = con.Query<Usuario>(sql);

                    return listaUsuariosRecebidos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Usuario BuscarUsuario(int idUsuario)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    con.Open();

                    string sql = "SELECT IdUsuario, NomeCompleto, DataNascimento, Email, Senha, DataCriado, Ativo, TipoUsuario FROM usuarios WHERE IdUsuario = @IdUsuario";

                    Usuario usuarioRecebido = con.QuerySingle<Usuario>(sql, new { IdUsuario = idUsuario });

                    return usuarioRecebido;
                }
            }
            catch (InvalidOperationException)
            {
                throw new UsuarioNaoEncontradoException("Usuário não encontrado");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Usuario BuscarUsuario(string emailUsuario)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    con.Open();

                    string sql = "SELECT IdUsuario, NomeCompleto, DataNascimento, Email, Senha, DataCriado, Ativo, TipoUsuario FROM usuarios WHERE Email = @Email";

                    return con.QuerySingle<Usuario>(sql, new { Email = emailUsuario });
                }
            }
            catch (InvalidOperationException)
            {
                throw new UsuarioNaoEncontradoException("Usuário não encontrado");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CriarUsuario(CreateUsuarioDTO usuarioRecebido)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    con.Open();

                    string insertSql = "INSERT INTO usuarios(NomeCompleto, DataNascimento, Email, Senha, TipoUsuario) VALUES(@NomeCompleto, @DataNascimento, @Email, @Senha, @TipoUsuario)";

                    con.Execute(insertSql, usuarioRecebido);

                    string getSql = "SELECT LAST_INSERT_ID()";

                    int idUsuarioRetornado = con.QuerySingle<int>(getSql, usuarioRecebido);

                    return idUsuarioRetornado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AtualizarUsuario(UpdateUsuarioDTO usuarioRecebido)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    con.Open();

                    string sql = "UPDATE usuarios SET NomeCompleto = @NomeCompleto, DataNascimento = @DataNascimento, Email = @Email, Senha = @Senha WHERE IdUsuario = @IdUsuario";

                    con.Execute(sql, usuarioRecebido);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoverUsuario(int idUsuario)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    con.Open();

                    string sql = "DELETE FROM usuarios WHERE IdUsuario = @IdUsuario";

                    con.Execute(sql, new { Idusuario = idUsuario });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
