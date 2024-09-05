using API.Data.DTO.Usuario;
using API.Domain.Exceptions;
using API.Domain.Models;
using API.Interfaces.DAO;
using Dapper;
using MySql.Data.MySqlClient;

namespace API.Data.DAO
{
    public class UsuarioDAO : IUsuarioDAO
    {
        private readonly string _connectionString = "server=127.0.0.1;uid=root;pwd=admin;database=gymapi";

        public IEnumerable<Usuario> BuscarUsuario()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    con.Open();

                    string sql = "SELECT IdUsuario, NomeCompleto, DataNascimento, Email, Senha, DataCriado, Ativo FROM usuarios";

                    var listaUsuariosRecebidos = con.Query<Usuario>(sql);

                    return listaUsuariosRecebidos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public Usuario BuscarUsuario(int idUsuario)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    con.Open();

                    string sql = "SELECT IdUsuario, NomeCompleto, DataNascimento, Email, Senha, DataCriado, Ativo FROM usuarios WHERE IdUsuario = @IdUsuario";

                    Usuario usuarioRecebido = con.QuerySingle<Usuario>(sql, new { IdUsuario = idUsuario });

                    return usuarioRecebido;
                }
            }
            catch(InvalidOperationException)
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

                    string insertSql = "INSERT INTO usuarios(NomeCompleto, DataNascimento, Email, Senha) VALUES(@NomeCompleto, @DataNascimento, @Email, @Senha)";

                    con.Execute(insertSql, usuarioRecebido);

                    string getSql = "SELECT LAST_INSERT_ID()";

                    int idUsuarioRetornado = con.QuerySingle<int>(getSql, usuarioRecebido);

                    return idUsuarioRetornado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
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
                throw new Exception();
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
                throw new Exception();
            }
        }
    }
}
