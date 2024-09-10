using API.Domain.Enums;

namespace API.Data.DTO.Autenticacao
{
    public class ReadAutenticacaoDTO
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
