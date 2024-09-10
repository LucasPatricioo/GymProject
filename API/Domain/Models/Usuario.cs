using API.Domain.Enums;

namespace API.Domain.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriado { get; set; }
        public bool Ativo { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
