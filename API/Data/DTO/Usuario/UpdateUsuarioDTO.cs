﻿namespace API.Data.DTO.Usuario
{
    public class UpdateUsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
