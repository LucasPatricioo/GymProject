namespace API.Data.DTO.Usuario
{
    public class CreateUsuarioDTO
    {
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
